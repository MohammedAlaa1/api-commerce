using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Reviews;
using FluentValidation;

namespace ECommerce.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ReviewValidationMessages.ReviewNotFound));

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage(LocalizerHelper.GetMessage(ReviewValidationMessages.RatingInvalid));
    }
}
