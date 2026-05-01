using ECommerce.Application.Common;
using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Features.Categories.Commands.DeleteCategory;
using ECommerce.Application.Features.Categories.Commands.UpdateCategory;
using ECommerce.Application.Features.Categories.Queries.GetAllCategories;
using ECommerce.Application.Features.Categories.Queries.GetCategoryById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Categories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CategoryValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CategoryValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CategoryValidationMessages.CreatedSuccessfully)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CategoryValidationMessages.UpdatedSuccessfully)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return Ok(ApiResponse.Success(result));
    }
}
