using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PaginatedResult<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllProductsHandler(IRepository<Product> productRepository, IMapper mapper, ICacheService cacheService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"products_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<ProductDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _productRepository.GetPagedAsync(request.PageNumber, request.PageSize, p => p.Brand, p => p.Category);

        var result = new PaginatedResult<ProductDto>
        {
            Data = _mapper.Map<IEnumerable<ProductDto>>(data.Where(p => p.IsActive)),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
