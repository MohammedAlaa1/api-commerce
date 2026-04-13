namespace ECommerce.Application.DTOs;

public class ProductDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public string? ImageUrl { get; set; }
    public string BrandName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
}
