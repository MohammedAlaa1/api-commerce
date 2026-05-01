using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginatedResult<CustomerDto>>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(IRepository<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        return new PaginatedResult<CustomerDto>
        {
            Data = _mapper.Map<IEnumerable<CustomerDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
