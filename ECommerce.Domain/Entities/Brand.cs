using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }

    // Navigation properties
    public List<Product> Products { get; set; } = new();
}
