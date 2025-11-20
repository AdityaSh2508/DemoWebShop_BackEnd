using System.Collections.Generic;

namespace MyCaseStudy.Models
{
    public class User
    {
        public int UserId { get; set; } // PK

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        // Navigation Properties
        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
