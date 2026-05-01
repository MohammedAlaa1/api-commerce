using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Addresses;
using FluentValidation;

namespace ECommerce.Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.StreetRequired));

        RuleFor(x => x.City)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.CityRequired));

        RuleFor(x => x.State)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.StateRequired));

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.CountryRequired));

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.PostalCodeRequired));

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.CustomerIdRequired));
    }
}
