using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateProductHandler(IRepository<Product> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product.IsActive = true;

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("products_1_10");

        return _mapper.Map<ProductDto>(product);
    }
}
