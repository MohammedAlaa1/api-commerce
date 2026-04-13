using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : ProductBaseCommand, IRequest<ProductDto>
{
    public Guid Id { get; set; }
}

