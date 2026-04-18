using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDto>>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public GetAllAddressesQueryHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var addresses = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AddressDto>>(addresses);
    }
}
