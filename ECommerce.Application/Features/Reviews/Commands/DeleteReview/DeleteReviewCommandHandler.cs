using ECommerce.Application.Helpers;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Resources.Reviews;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IRepository<Review> _repository;
    private readonly ICacheService _cacheService;

    public DeleteReviewCommandHandler(IRepository<Review> repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _repository.GetByIdAsync(request.Id);
        if (review is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ReviewValidationMessages.ReviewNotFound));

        _repository.Delete(review);
        await _repository.SaveChangesAsync();
        await _cacheService.RemoveAsync("reviews_1_10");
    }
}
