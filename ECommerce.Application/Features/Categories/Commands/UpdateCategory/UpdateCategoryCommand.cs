using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : CategoryBaseCommand, IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
