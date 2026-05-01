using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<PaginatedResult<CustomerDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
