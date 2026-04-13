using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}
