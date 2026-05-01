using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Customers;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IRepository<Customer> _repository;
    private readonly ICacheService _cacheService;

    public DeleteCustomerCommandHandler(IRepository<Customer> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(CustomerValidationMessages.CustomerNotFound));

        _repository.Delete(customer);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("customers_1_10");
    }
}
