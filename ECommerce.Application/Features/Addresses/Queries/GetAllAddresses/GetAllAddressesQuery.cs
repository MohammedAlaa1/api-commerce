using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQuery : IRequest<IEnumerable<AddressDto>>
{
}
