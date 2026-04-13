using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CategoryValidationMessages.CategoryNotFound));

        _repository.Delete(category);
        await _repository.SaveChangesAsync();

        return LocalizerHelper.GetMessage(CategoryValidationMessages.DeletedSuccessfully);
    }
}
