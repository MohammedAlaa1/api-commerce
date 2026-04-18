using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Addresses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.DeleteAddress;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IRepository<Address> _repository;

    public DeleteAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _repository.GetByIdAsync(request.Id);
        if (address is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(AddressValidationMessages.AddressNotFound));

        _repository.Delete(address);
        await _repository.SaveChangesAsync();
    }
}
