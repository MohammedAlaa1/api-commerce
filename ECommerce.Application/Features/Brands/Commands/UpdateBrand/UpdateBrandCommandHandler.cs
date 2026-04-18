using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandDto>
{
    private readonly IRepository<Brand> _repository;
    private readonly IMapper _mapper;

    public UpdateBrandCommandHandler(IRepository<Brand> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(BrandValidationMessages.BrandNotFound));

        _mapper.Map(request, brand);
        _repository.Update(brand);
        await _repository.SaveChangesAsync();
        return _mapper.Map<BrandDto>(brand);
    }
}
