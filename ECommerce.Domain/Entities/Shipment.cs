using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Shipment : BaseEntity
{
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
    public string? TrackingNumber { get; set; }
    public string? Carrier { get; set; }            // e.g. "FedEx", "DHL", "UPS"
    public DateTime? EstimatedDelivery { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }

    // Foreign key
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}
