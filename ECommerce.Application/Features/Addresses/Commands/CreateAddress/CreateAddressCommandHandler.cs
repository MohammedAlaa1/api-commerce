using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDto>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Address>(request);
        await _repository.AddAsync(address);
        await _repository.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }
}
