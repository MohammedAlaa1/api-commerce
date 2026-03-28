using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    // Self-referencing relationship: a Category can have a parent Category
    // e.g. "Shoes" is a sub-category of "Clothing"
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = new();

    // Navigation properties
    public List<Product> Products { get; set; } = new();
}
