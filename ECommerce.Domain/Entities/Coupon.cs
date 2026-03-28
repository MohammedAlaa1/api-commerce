using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; set; } = null!;      // e.g. "SUMMER20"
    public DiscountType DiscountType { get; set; }
    public decimal DiscountValue { get; set; }      // e.g. 20 (for 20% or $20 depending on type)
    public decimal? MinOrderAmount { get; set; }    // Minimum cart total to apply the coupon
    public int MaxUsageCount { get; set; }          // How many times it can be used in total
    public int UsageCount { get; set; }             // How many times it has been used so far
    public DateTime ExpiresAt { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public List<Order> Orders { get; set; } = new();
}
