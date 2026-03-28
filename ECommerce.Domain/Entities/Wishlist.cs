using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Wishlist : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public List<WishlistItem> Items { get; set; } = new();
}
