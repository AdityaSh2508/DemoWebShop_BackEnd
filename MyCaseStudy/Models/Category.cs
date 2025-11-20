using System.Collections.Generic;

namespace MyCaseStudy.Models
{
    public class Category
    {
        public int CategoryId { get; set; } // PK

        public string CategoryName { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; }
    }
}
