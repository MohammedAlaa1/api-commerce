using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using FluentValidation;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(BrandValidationMessages.NameRequired))
            .MaximumLength(200).WithMessage(LocalizerHelper.GetMessage(BrandValidationMessages.NameTooLong));
    }
}
