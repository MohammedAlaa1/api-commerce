using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<CustomerDto>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
