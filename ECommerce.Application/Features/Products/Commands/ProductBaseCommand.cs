namespace ECommerce.Application.Features.Products.Commands;

public abstract class ProductBaseCommand
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public string? ImageUrl { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
}
