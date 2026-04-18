using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Auth;
using FluentValidation;

namespace ECommerce.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.EmailRequired))
            .EmailAddress().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.EmailInvalid));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.PasswordRequired));
    }
}
