using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IRepository<Product> _repository;
        public CreateProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                BasePrice = request.BasePrice,
                ImageUrl = request.ImageUrl,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                IsActive = true
            };

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                ImageUrl = product.ImageUrl,
                BrandName = string.Empty,
                CategoryName = string.Empty
            };
        }
    }
}
