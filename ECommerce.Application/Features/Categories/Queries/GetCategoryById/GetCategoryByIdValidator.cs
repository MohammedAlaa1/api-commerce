using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CategoryValidationMessages.IdRequired));
    }
}
