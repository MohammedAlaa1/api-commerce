using ECommerce.Application.Common;
using ECommerce.Application.Features.Customers.Commands.CreateCustomer;
using ECommerce.Application.Features.Customers.Commands.DeleteCustomer;
using ECommerce.Application.Features.Customers.Commands.UpdateCustomer;
using ECommerce.Application.Features.Customers.Queries.GetAllCustomers;
using ECommerce.Application.Features.Customers.Queries.GetCustomerById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Customers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetAllCustomersQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CustomerValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CustomerValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CustomerValidationMessages.CreatedSuccessfully)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(CustomerValidationMessages.UpdatedSuccessfully)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCustomerCommand { Id = id });
        return Ok(ApiResponse.Success(null, LocalizerHelper.GetMessage(CustomerValidationMessages.DeletedSuccessfully)));
    }
}
