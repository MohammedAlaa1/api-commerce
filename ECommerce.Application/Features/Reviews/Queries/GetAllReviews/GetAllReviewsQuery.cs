using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsQuery : IRequest<PaginatedResult<ReviewDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
