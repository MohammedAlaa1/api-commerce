using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Addresses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, AddressDto>
{
    private readonly IRepository<Address> _repository;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _repository.GetByIdAsync(request.Id);
        if (address is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(AddressValidationMessages.AddressNotFound));

        _mapper.Map(request, address);
        _repository.Update(address);
        await _repository.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }
}
