using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Order : BaseEntity
{
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public DateTime? PaidAt { get; set; }

    // Every order has a customer
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Two addresses: where the invoice goes and where the package goes
    public Guid BillingAddressId { get; set; }
    public Address BillingAddress { get; set; } = null!;

    public Guid ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; } = null!;

    // Optional coupon applied to this order
    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }

    // Collections
    public List<OrderItem> Items { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
    public List<Shipment> Shipments { get; set; } = new();
}
