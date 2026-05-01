using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Reviews;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewDto>
{
    private readonly IRepository<Review> _repository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public UpdateReviewCommandHandler(IRepository<Review> repository, IMapper mapper, ICacheService cacheService)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<ReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _repository.GetByIdAsync(request.Id);
        if (review is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ReviewValidationMessages.ReviewNotFound));

        _mapper.Map(request, review);
        _repository.Update(review);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("reviews_1_10");
        return _mapper.Map<ReviewDto>(review);
    }
}
