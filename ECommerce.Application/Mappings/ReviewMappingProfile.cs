using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Features.Reviews.Commands.CreateReview;
using ECommerce.Application.Features.Reviews.Commands.UpdateReview;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<CreateReviewCommand, Review>();
        CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, ReviewDto>();
    }
}
