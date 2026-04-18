using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Commands.UpdateBrand;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings;

public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<CreateBrandCommand, Brand>();
        CreateMap<UpdateBrandCommand, Brand>();
        CreateMap<Brand, BrandDto>();
    }
}
