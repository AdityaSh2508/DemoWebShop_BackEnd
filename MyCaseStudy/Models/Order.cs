using System;
using System.Collections.Generic;

namespace MyCaseStudy.Models
{
    public class Order
    {
        public int OrderId { get; set; } // PK

        public int UserId { get; set; } // FK

        public DateTime OrderDate { get; set; }

        public string PaymentMethod { get; set; }

        // Navigation
        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
