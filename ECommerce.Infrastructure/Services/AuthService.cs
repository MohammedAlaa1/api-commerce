using ECommerce.Application.DTOs.Auth;
using ECommerce.Application.Features.Auth.Commands;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using ECommerce.Infrastructure.Identity;
using ECommerce.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _context;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager, AppDbContext context, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _context = context;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterCommand request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
            throw new Exception("Email already exists");

        var user = new ApplicationUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            TenantId = request.TenantId
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        var (token, expiresAt) = GenerateJwt(user);
        var refreshToken = GenerateRefreshToken(user.Id);

        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            AccessToken = token,
            RefreshToken = refreshToken.Token,
            ExpiresAt = expiresAt
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
            throw new Exception("Invalid credentials");

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
            throw new Exception("Invalid credentials");

        var (token, expiresAt) = GenerateJwt(user);
        var refreshToken = GenerateRefreshToken(user.Id);

        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            AccessToken = token,
            RefreshToken = refreshToken.Token,
            ExpiresAt = expiresAt
        };
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var storedToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (storedToken is null)
            throw new Exception("Invalid refresh token");

        if (storedToken.IsRevoked)
            throw new Exception("Refresh token has been revoked");

        if (storedToken.IsUsed)
            throw new Exception("Refresh token has already been used");

        if (storedToken.ExpiresAt < DateTime.UtcNow)
            throw new Exception("Refresh token has expired");

        storedToken.IsUsed = true;
        _context.RefreshTokens.Update(storedToken);

        var user = await _userManager.FindByIdAsync(storedToken.UserId);
        if (user is null)
            throw new Exception("User not found");

        var (token, expiresAt) = GenerateJwt(user);
        var newRefreshToken = GenerateRefreshToken(user.Id);

        await _context.RefreshTokens.AddAsync(newRefreshToken);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            AccessToken = token,
            RefreshToken = newRefreshToken.Token,
            ExpiresAt = expiresAt
        };
    }

    public async Task LogoutAsync(string refreshToken)
    {
        var storedToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (storedToken is null)
            throw new Exception("Invalid refresh token");

        storedToken.IsRevoked = true;
        _context.RefreshTokens.Update(storedToken);
        await _context.SaveChangesAsync();
    }

    private (string token, DateTime expiresAt) GenerateJwt(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim("TenantId", user.TenantId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }

    private RefreshToken GenerateRefreshToken(string userId)
    {
        return new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = Guid.NewGuid().ToString(),
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays),
            IsRevoked = false,
            IsUsed = false
        };
    }
}
