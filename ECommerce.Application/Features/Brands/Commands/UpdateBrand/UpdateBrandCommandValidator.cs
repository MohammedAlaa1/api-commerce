using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using FluentValidation;

namespace ECommerce.Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(BrandValidationMessages.BrandNotFound));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(BrandValidationMessages.NameRequired))
            .MaximumLength(200).WithMessage(LocalizerHelper.GetMessage(BrandValidationMessages.NameTooLong));
    }
}
