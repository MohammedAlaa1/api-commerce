using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

// A discount is applied directly to products (not via a coupon code)
// e.g. "Black Friday Sale - 30% off all shoes"
public class Discount : BaseEntity
{
    public string Name { get; set; } = null!;
    public DiscountType DiscountType { get; set; }
    public decimal DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public List<Product> Products { get; set; } = new();
}
