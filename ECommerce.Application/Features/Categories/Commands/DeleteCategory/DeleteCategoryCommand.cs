using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<string>
{
    public Guid Id { get; set; }
}
