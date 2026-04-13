using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands;

public class CategoryBaseValidator<T> : AbstractValidator<T> where T : CategoryBaseCommand
{
    public CategoryBaseValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(CategoryValidationMessages.NameRequired))
            .MaximumLength(200).WithMessage(LocalizerHelper.GetMessage(CategoryValidationMessages.NameTooLong));
    }
}
