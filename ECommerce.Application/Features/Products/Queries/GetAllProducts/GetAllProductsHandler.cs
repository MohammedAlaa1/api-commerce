using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PaginatedResult<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _productRepository.GetPagedAsync(request.PageNumber, request.PageSize, p => p.Brand, p => p.Category);

        return new PaginatedResult<ProductDto>
        {
            Data = _mapper.Map<IEnumerable<ProductDto>>(data.Where(p => p.IsActive)),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
