using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public UpdateProductHandler(IRepository<Product> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ProductValidationMessages.ProductNotFound));

        _mapper.Map(request, product);
        product.UpdatedAt = DateTime.UtcNow;

        _repository.Update(product);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("products_1_10");

        return _mapper.Map<ProductDto>(product);
    }
}
