using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest<BrandDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
}
