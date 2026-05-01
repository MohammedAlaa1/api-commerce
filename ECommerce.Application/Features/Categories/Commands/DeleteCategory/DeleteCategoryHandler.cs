using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Categories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    private readonly IRepository<Category> _repository;
    private readonly ICacheService _cacheService;

    public DeleteCategoryHandler(IRepository<Category> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CategoryValidationMessages.CategoryNotFound));

        _repository.Delete(category);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("categories_1_10");

        return LocalizerHelper.GetMessage(CategoryValidationMessages.DeletedSuccessfully);
    }
}
