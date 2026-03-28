using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? TransactionId { get; set; }  // The ID returned by the payment provider (e.g. Stripe)
    public DateTime? PaidAt { get; set; }

    // Foreign key
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
