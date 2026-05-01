using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, PaginatedResult<ReviewDto>>
{
    private readonly IRepository<Review> _repository;
    private readonly IMapper _mapper;

    public GetAllReviewsQueryHandler(IRepository<Review> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        return new PaginatedResult<ReviewDto>
        {
            Data = _mapper.Map<IEnumerable<ReviewDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
