using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Brands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IRepository<Brand> _repository;
    private readonly ICacheService _cacheService;

    public DeleteBrandCommandHandler(IRepository<Brand> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(BrandValidationMessages.BrandNotFound));

        _repository.Delete(brand);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("brands_1_10");
    }
}
