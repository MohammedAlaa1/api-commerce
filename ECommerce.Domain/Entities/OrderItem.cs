using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }

    // IMPORTANT: We store the price at the time of purchase.
    // If the product price changes later, the order history stays accurate.
    public decimal UnitPrice { get; set; }

    // Foreign keys
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; } = null!;
}
