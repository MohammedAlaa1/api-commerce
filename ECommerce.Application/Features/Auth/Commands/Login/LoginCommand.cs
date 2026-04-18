using ECommerce.Application.DTOs.Auth;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<AuthResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
