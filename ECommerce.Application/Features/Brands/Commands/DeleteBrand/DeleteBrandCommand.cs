using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest
{
    public Guid Id { get; set; }
}
