using AutoMapper;
using ECommerce.Application.Common;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginatedResult<CustomerDto>>
{
    private readonly IRepository<Customer> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetAllCustomersQueryHandler(IRepository<Customer> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<PaginatedResult<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"customers_{request.PageNumber}_{request.PageSize}";

        var cached = await _cacheService.GetAsync<PaginatedResult<CustomerDto>>(cacheKey);
        if (cached is not null)
            return cached;

        var (data, totalCount) = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);

        var result = new PaginatedResult<CustomerDto>
        {
            Data = _mapper.Map<IEnumerable<CustomerDto>>(data),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };

        await _cacheService.SetAsync(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }
}
