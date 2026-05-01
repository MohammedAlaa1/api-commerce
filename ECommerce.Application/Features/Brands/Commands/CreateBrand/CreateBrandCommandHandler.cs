using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandDto>
{
    private readonly IRepository<Brand> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateBrandCommandHandler(IRepository<Brand> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = _mapper.Map<Brand>(request);
        await _repository.AddAsync(brand);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("brands_1_10");
        return _mapper.Map<BrandDto>(brand);
    }
}
