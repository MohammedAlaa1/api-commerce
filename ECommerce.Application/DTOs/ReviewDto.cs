namespace ECommerce.Application.DTOs;

public class ReviewDto : BaseDto
{
    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
}
