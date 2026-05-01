using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<PaginatedResult<CategoryDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
