using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Customers;
using FluentValidation;

namespace ECommerce.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.CustomerNotFound));

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.FirstNameRequired));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.LastNameRequired));

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.EmailRequired))
            .EmailAddress().WithMessage(LocalizerHelper.GetMessage(CustomerValidationMessages.EmailInvalid));
    }
}
