using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.NameRequired))
            .MaximumLength(200).WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.NameTooLong));

        RuleFor(x => x.BasePrice)
            .GreaterThan(0).WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.PriceInvalid));

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.BrandRequired));

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.CategoryRequired));
    }
}
