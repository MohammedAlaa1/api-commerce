using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Features.Customers.Commands.CreateCustomer;
using ECommerce.Application.Features.Customers.Commands.UpdateCustomer;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<Customer, CustomerDto>();
    }
}
