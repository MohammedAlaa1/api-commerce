namespace ECommerce.Application.Features.Categories.Commands;

public abstract class CategoryBaseCommand
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
