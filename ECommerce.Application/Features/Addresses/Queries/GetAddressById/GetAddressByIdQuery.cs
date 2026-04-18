using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAddressById;

public class GetAddressByIdQuery : IRequest<AddressDto>
{
    public Guid Id { get; set; }
}
