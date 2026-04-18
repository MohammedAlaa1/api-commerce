using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>
{
}
