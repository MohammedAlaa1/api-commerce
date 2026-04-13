using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CategoryValidationMessages.IdRequired));
    }
}
