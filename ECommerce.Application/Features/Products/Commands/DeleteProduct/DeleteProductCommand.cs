using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<string>
{
    public Guid Id { get; set; }
}
