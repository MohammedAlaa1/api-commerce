using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDto>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Address>(request);
        await _repository.AddAsync(address);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("addresses_1_10");
        return _mapper.Map<AddressDto>(address);
    }
}
