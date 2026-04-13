using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
{
    private readonly IRepository<Product> _repository;

    public DeleteProductHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ProductValidationMessages.ProductNotFound));

        _repository.Delete(product);
        await _repository.SaveChangesAsync();

        return LocalizerHelper.GetMessage(ProductValidationMessages.DeletedSuccessfully);
    }
}
