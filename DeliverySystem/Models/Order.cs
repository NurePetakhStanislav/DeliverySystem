using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public int? CourierId { get; set; }
        public int FromStreetId { get; set; }
        public int ToStreetId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal RewardFee { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
