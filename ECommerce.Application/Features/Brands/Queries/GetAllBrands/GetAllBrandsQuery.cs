using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandsQuery : IRequest<PaginatedResult<BrandDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
