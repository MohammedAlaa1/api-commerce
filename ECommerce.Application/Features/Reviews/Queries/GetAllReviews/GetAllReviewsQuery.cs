using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsQuery : IRequest<IEnumerable<ReviewDto>>
{
}
