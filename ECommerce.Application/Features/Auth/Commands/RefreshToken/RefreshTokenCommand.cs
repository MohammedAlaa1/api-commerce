using ECommerce.Application.DTOs.Auth;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<AuthResponse>
{
    public string RefreshToken { get; set; } = null!;
}
