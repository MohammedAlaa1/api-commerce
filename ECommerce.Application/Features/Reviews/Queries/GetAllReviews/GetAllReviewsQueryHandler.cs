using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, PaginatedResult<ReviewDto>>
{
    private readonly IRepository<Review> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllReviewsQueryHandler(IRepository<Review> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"reviews_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<ReviewDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        var result = new PaginatedResult<ReviewDto>
        {
            Data = _mapper.Map<IEnumerable<ReviewDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
