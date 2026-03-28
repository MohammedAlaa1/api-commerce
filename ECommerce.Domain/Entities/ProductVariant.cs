using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

// A variant is a specific version of a product, e.g. "Nike Air Max - Size 42 - Red"
public class ProductVariant : BaseEntity
{
    public string SKU { get; set; } = null!;  // Stock Keeping Unit - unique identifier per variant
    public string? Color { get; set; }
    public string? Size { get; set; }
    public decimal Price { get; set; }         // Can override the product's BasePrice

    // Foreign key
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    // Navigation properties
    public Inventory? Inventory { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public List<CartItem> CartItems { get; set; } = new();
}
