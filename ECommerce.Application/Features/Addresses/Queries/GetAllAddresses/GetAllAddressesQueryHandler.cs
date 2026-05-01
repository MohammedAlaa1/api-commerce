using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, PaginatedResult<AddressDto>>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public GetAllAddressesQueryHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        return new PaginatedResult<AddressDto>
        {
            Data = _mapper.Map<IEnumerable<AddressDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
