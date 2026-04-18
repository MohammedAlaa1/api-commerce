using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    public Guid Id { get; set; }
}
