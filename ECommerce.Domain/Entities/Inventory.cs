using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Inventory : BaseEntity
{
    public int QuantityAvailable { get; set; }
    public int QuantityReserved { get; set; }   // Items in active carts/orders but not yet shipped
    public string? WarehouseLocation { get; set; }

    // A 1-to-1 relationship: each ProductVariant has exactly one Inventory record
    public Guid ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; } = null!;
}
