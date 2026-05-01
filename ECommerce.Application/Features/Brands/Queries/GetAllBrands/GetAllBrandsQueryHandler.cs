using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, PaginatedResult<BrandDto>>
{
    private readonly IRepository<Brand> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllBrandsQueryHandler(IRepository<Brand> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"brands_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<BrandDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        var result = new PaginatedResult<BrandDto>
        {
            Data = _mapper.Map<IEnumerable<BrandDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
