using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    // Navigation properties
    public List<Address> Addresses { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
    public Wishlist? Wishlist { get; set; }
    public Cart? Cart { get; set; }
}
