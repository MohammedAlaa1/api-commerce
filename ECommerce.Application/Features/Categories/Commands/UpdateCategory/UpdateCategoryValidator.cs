using ECommerce.Application.Features.Categories.Commands;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryValidator : CategoryBaseValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CategoryValidationMessages.IdRequired));
    }
}
