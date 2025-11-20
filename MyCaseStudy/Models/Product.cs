using System.Collections.Generic;

namespace MyCaseStudy.Models
{
    public class Product
    {
        public int ProductId { get; set; } // PK

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; } // FK

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public string ProductUrl { get; set; }

        // Navigation
        public Category Category { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
