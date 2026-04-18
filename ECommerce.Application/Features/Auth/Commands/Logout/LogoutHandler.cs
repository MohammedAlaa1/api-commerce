using ECommerce.Application.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Logout;

public class LogoutHandler : IRequestHandler<LogoutCommand>
{
    private readonly IAuthService _authService;

    public LogoutHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _authService.LogoutAsync(request.RefreshToken);
    }
}
