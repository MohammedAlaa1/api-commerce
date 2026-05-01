using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, PaginatedResult<AddressDto>>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllAddressesQueryHandler(IRepository<Address> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"addresses_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<AddressDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        var result = new PaginatedResult<AddressDto>
        {
            Data = _mapper.Map<IEnumerable<AddressDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
