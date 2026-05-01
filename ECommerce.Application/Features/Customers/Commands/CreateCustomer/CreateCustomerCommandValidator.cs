using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Customers;
using FluentValidation;

namespace ECommerce.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.FirstNameRequired));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.LastNameRequired));

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.EmailRequired))
            .EmailAddress().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.EmailInvalid));
    }
}
