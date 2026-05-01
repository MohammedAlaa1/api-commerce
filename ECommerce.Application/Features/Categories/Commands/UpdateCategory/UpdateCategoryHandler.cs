using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Categories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public UpdateCategoryHandler(IRepository<Category> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CategoryValidationMessages.CategoryNotFound));

        _mapper.Map(request, category);

        _repository.Update(category);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("categories_1_10");

        return _mapper.Map<CategoryDto>(category);
    }
}
