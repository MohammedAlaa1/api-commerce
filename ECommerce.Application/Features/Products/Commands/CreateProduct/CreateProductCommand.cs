using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : ProductBaseCommand, IRequest<ProductDto>
{
}

