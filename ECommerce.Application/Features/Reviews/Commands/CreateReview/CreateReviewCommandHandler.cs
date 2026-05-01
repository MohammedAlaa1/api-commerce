using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    private readonly IRepository<Review> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public CreateReviewCommandHandler(IRepository<Review> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Review>(request);
        await _repository.AddAsync(review);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("reviews_1_10");
        return _mapper.Map<ReviewDto>(review);
    }
}
