using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public bool IsDefault { get; set; }

    // Foreign key
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}
