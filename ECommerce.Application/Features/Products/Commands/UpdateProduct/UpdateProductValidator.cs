using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductValidator : ProductBaseValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.IdRequired));
    }
}

