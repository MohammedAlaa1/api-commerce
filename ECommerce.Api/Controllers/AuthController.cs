using ECommerce.Application.Common;
using ECommerce.Application.Features.Auth.Commands;
using ECommerce.Application.Features.Auth.Commands.Login;
using ECommerce.Application.Features.Auth.Commands.Logout;
using ECommerce.Application.Features.Auth.Commands.RefreshToken;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AuthValidationMessages.RegisteredSuccessfully)));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AuthValidationMessages.LoggedInSuccessfully)));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AuthValidationMessages.TokenRefreshedSuccessfully)));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout(LogoutCommand request)
    {
        await _mediator.Send(request);
        return Ok(ApiResponse.Success(null, LocalizerHelper.GetMessage(AuthValidationMessages.LoggedOutSuccessfully)));
    }
}
