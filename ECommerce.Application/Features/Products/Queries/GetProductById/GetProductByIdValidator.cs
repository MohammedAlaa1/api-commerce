using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using FluentValidation;

namespace ECommerce.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ProductValidationMessages.IdRequired));
    }
}
