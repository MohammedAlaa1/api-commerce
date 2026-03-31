using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Cart : BaseEntity
{
    // A cart belongs to one customer
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public List<CartItem> Items { get; set; } = new();
}
