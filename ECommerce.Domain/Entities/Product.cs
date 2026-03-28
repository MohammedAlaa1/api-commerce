using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;

    // Foreign keys
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // Navigation properties
    public List<ProductVariant> Variants { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}
