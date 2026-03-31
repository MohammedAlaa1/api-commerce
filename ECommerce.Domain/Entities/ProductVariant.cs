using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public string SKU { get; set; } = null!;
    public string? Color { get; set; }
    public string? Size { get; set; }
    public decimal Price { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public Inventory? Inventory { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public List<CartItem> CartItems { get; set; } = new();
}
