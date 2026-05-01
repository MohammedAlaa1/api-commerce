using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommand : IRequest<AddressDto>
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public bool IsDefault { get; set; }
    public Guid CustomerId { get; set; }
}
