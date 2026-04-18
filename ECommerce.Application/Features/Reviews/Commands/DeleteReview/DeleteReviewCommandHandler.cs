using ECommerce.Application.Helpers;
using ECommerce.Application.Resources.Reviews;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
{
    private readonly IRepository<Review> _repository;

    public DeleteReviewCommandHandler(IRepository<Review> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _repository.GetByIdAsync(request.Id);
        if (review is null)
            throw new KeyNotFoundException(LocalizerHelper.GetMessage(ReviewValidationMessages.ReviewNotFound));

        _repository.Delete(review);
        await _repository.SaveChangesAsync();
    }
}
