using ECommerce.Application.Common;
using ECommerce.Application.Features.Addresses.Commands.CreateAddress;
using ECommerce.Application.Features.Addresses.Commands.DeleteAddress;
using ECommerce.Application.Features.Addresses.Commands.UpdateAddress;
using ECommerce.Application.Features.Addresses.Queries.GetAllAddresses;
using ECommerce.Application.Features.Addresses.Queries.GetAddressById;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Addresses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(new GetAllAddressesQuery { PageNumber = pageNumber, PageSize = pageSize });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AddressValidationMessages.FetchedSuccessfully)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetAddressByIdQuery { Id = id });
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AddressValidationMessages.FetchedSuccessfully)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAddressCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AddressValidationMessages.CreatedSuccessfully)));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAddressCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(ApiResponse.Success(result, LocalizerHelper.GetMessage(AddressValidationMessages.UpdatedSuccessfully)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteAddressCommand { Id = id });
        return Ok(ApiResponse.Success(null, LocalizerHelper.GetMessage(AddressValidationMessages.DeletedSuccessfully)));
    }
}
