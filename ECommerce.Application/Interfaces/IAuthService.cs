using ECommerce.Application.DTOs.Auth;
using ECommerce.Application.Features.Auth.Commands;
using ECommerce.Application.Features.Auth.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterCommand request);
        Task<AuthResponse> LoginAsync(LoginCommand request);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(string refreshToken);
    }
}
