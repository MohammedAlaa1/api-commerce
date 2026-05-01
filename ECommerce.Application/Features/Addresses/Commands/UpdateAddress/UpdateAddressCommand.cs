using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressCommand : IRequest<AddressDto>
{
    public Guid Id { get; set; }
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public bool IsDefault { get; set; }
}
