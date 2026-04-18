using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewCommand : IRequest
{
    public Guid Id { get; set; }
}
