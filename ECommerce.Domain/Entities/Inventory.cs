using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Inventory : BaseEntity
{
    public int QuantityAvailable { get; set; }
    public int QuantityReserved { get; set; }
    public string? WarehouseLocation { get; set; }

    public Guid ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; set; } = null!;
}
