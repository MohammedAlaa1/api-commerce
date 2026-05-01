using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<BrandDto>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
}
