using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PaginatedResult<CategoryDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllCategoriesHandler(IRepository<Category> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"categories_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<CategoryDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, c => c.ParentCategory);

        var result = new PaginatedResult<CategoryDto>
        {
            Data = _mapper.Map<IEnumerable<CategoryDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
