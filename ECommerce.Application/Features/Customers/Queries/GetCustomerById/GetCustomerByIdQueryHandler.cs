using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Customers;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(IRepository<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CustomerValidationMessages.CustomerNotFound));

        return _mapper.Map<CustomerDto>(customer);
    }
}
