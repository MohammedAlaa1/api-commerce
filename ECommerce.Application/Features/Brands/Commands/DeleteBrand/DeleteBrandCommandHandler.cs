using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IRepository<Brand> _repository;

    public DeleteBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(BrandValidationMessages.BrandNotFound));

        _repository.Delete(brand);
        await _repository.SaveChangesAsync();
    }
}
