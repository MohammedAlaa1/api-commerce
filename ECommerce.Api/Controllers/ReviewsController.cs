using ECommerce.Application.Common;
using ECommerce.Application.Features.Reviews.Commands.CreateReview;
using ECommerce.Application.Features.Reviews.Commands.DeleteReview;
using ECommerce.Application.Features.Reviews.Commands.UpdateReview;
using ECommerce.Application.Features.Reviews.Queries.GetAllReviews;
using ECommerce.Application.Features.Reviews.Queries.GetReviewById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Reviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetAllReviewsQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ReviewValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetReviewByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ReviewValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ReviewValidationMessages.CreatedSuccessfully)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateReviewCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(ReviewValidationMessages.UpdatedSuccessfully)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteReviewCommand { Id = id });
        return Ok(ApiResponse.Success(null, LocalizerHelper.GetMessage(ReviewValidationMessages.DeletedSuccessfully)));
    }
}
