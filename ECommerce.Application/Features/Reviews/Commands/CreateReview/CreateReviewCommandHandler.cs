using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Reviews.Commands.CreateReview;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    private readonly IRepository<Review> _repository;
    private readonly IMapper _mapper;

    public CreateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Review>(request);
        await _repository.AddAsync(review);
        await _repository.SaveChangesAsync();
        return _mapper.Map<ReviewDto>(review);
    }
}
