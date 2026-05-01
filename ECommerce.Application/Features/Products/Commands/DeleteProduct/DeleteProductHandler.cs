using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
{
    private readonly IRepository<Product> _repository;
    private readonly ICacheService _cacheService;

    public DeleteProductHandler(IRepository<Product> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ProductValidationMessages.ProductNotFound));

        _repository.Delete(product);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("products_1_10");

        return LocalizerHelper.GetMessage(ProductValidationMessages.DeletedSuccessfully);
    }
}
