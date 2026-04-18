using ECommerce.Application.Common;
using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Commands.DeleteBrand;
using ECommerce.Application.Features.Brands.Commands.UpdateBrand;
using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using ECommerce.Application.Features.Brands.Queries.GetBrandById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Brands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(BrandValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBrandByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(BrandValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(BrandValidationMessages.CreatedSuccessfully)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBrandCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(BrandValidationMessages.UpdatedSuccessfully)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteBrandCommand { Id = id });
        return Ok(ApiResponse.Success(null, LocalizerHelper.GetMessage(BrandValidationMessages.DeletedSuccessfully)));
    }
}
