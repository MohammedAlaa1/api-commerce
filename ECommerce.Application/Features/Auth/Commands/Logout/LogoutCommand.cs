using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Logout;

public class LogoutCommand : IRequest
{
    public string RefreshToken { get; set; } = null!;
}
