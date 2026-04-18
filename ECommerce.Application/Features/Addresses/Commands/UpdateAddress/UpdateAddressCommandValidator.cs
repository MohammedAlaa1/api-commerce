using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Addresses;
using FluentValidation;

namespace ECommerce.Application.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(AddressValidationMessages.AddressNotFound));

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
    }
}
