using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
}
