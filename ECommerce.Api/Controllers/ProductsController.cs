using ECommerce.Application.Common;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using ECommerce.Application.Features.Products.Queries.GetProductById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ProductValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ProductValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ProductValidationMessages.CreatedSuccessfully)));
    }
}
