using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommand : IRequest<ReviewDto>
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}
