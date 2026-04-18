using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Auth;
using FluentValidation;

namespace ECommerce.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.FirstNameRequired));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.LastNameRequired));

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.EmailRequired))
            .EmailAddress().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.EmailInvalid));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.PasswordRequired))
            .MinimumLength(8).WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.PasswordTooShort));

        RuleFor(x => x.TenantId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AuthValidationMessages.TenantIdRequired));
    }
}
