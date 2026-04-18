namespace ECommerce.Application.DTOs;

public class BrandDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
}
