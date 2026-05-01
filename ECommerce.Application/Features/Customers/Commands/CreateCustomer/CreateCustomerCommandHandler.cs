using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _repository.AddAsync(customer);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("customers_1_10");
        return _mapper.Map<CustomerDto>(customer);
    }
}
