using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public required string Status { get; set; }
        public required List<OrderItem> Items { get; set; }
        public Guid CustomerId { get; set; } 
        public Customer Customer { get; set; }
        public Guid BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Shipment> Shipments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
