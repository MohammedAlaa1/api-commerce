using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommand : IRequest<ReviewDto>
{
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
}
