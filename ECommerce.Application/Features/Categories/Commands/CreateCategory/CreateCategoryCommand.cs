using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : CategoryBaseCommand, IRequest<CategoryDto>
{
}
