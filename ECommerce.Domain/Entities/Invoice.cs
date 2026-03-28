using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Invoice : BaseEntity
{
    public string InvoiceNumber { get; set; } = null!;  // e.g. "INV-2026-00042"
    public decimal TotalAmount { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime DueAt { get; set; }
    public bool IsPaid { get; set; }

    // Foreign key
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
