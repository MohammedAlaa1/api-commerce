using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }

    // Foreign keys
    public Guid CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public Guid ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; } = null!;
}
