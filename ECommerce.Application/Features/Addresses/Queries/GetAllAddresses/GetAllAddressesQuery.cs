using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQuery : IRequest<PaginatedResult<AddressDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
