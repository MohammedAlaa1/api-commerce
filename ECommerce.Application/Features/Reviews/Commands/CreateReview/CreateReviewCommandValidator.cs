using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Reviews;
using FluentValidation;

namespace ECommerce.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage(LocalizerHelper.GetMessage(ReviewValidationMessages.RatingInvalid));

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ReviewValidationMessages.CustomerIdRequired));

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage(LocalizerHelper.GetMessage(ReviewValidationMessages.ProductIdRequired));
    }
}
