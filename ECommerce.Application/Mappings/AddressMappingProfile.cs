using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Features.Addresses.Commands.CreateAddress;
using ECommerce.Application.Features.Addresses.Commands.UpdateAddress;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<CreateAddressCommand, Address>();
        CreateMap<UpdateAddressCommand, Address>();
        CreateMap<Address, AddressDto>();
    }
}
