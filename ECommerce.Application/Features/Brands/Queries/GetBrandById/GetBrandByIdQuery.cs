using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQuery : IRequest<BrandDto>
{
    public Guid Id { get; set; }
}
