using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PaginatedResult<CategoryDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, c => c.ParentCategory);

        return new PaginatedResult<CategoryDto>
        {
            Data = _mapper.Map<IEnumerable<CategoryDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
