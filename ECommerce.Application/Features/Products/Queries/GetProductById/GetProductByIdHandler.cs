using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetProductById
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepository<Product> _repository;
        public GetProductByIdHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, p => p.Brand, p => p.Category);

            if (product == null)
                throw new KeyNotFoundException("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                ImageUrl = product.ImageUrl,
                BrandName = product.Brand.Name,
                CategoryName = product.Category.Name
            };
        }
    }
}
