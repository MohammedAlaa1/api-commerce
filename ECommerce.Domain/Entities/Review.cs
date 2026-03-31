using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Review : BaseEntity
{
    public int Rating { get; set; }         // 1 to 5 stars
    public string? Title { get; set; }
    public string? Body { get; set; }
    public bool IsVerifiedPurchase { get; set; }

    // Foreign keys
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
