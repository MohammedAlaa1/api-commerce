using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Customers;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public UpdateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CustomerValidationMessages.CustomerNotFound));

        _mapper.Map(request, customer);
        _repository.Update(customer);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("customers_1_10");
        return _mapper.Map<CustomerDto>(customer);
    }
}
