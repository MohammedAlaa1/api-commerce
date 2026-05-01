using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, PaginatedResult<BrandDto>>
{
    private readonly IRepository<Brand> _repository;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryHandler(IRepository<Brand> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        return new PaginatedResult<BrandDto>
        {
            Data = _mapper.Map<IEnumerable<BrandDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
