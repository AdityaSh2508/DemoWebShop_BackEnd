namespace MyCaseStudy.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; } // PK

        public int UserId { get; set; } // FK

        public int ProductId { get; set; } // FK

        public int Quantity { get; set; }

        // Navigation
        public User User { get; set; }

        public Product Product { get; set; }
    }
}
