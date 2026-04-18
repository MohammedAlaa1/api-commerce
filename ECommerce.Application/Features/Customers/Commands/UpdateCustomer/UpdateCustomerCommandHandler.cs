using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Customers;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CustomerValidationMessages.CustomerNotFound));

        _mapper.Map(request, customer);
        _repository.Update(customer);
        await _repository.SaveChangesAsync();
        return _mapper.Map<CustomerDto>(customer);
    }
}
