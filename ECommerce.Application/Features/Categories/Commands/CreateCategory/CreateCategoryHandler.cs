using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateCategoryHandler(IRepository<Category> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("categories_1_10");

        return _mapper.Map<CategoryDto>(category);
    }
}
