using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
{
    private readonly IRepository<Brand> _repository;
    private readonly IMapper _mapper;

    public GetBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(BrandValidationMessages.BrandNotFound));

        return _mapper.Map<BrandDto>(brand);
    }
}
