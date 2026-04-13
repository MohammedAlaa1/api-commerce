using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.IdRequired));
    }
}
