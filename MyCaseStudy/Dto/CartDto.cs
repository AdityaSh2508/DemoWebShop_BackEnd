namespace MyCaseStudy.Dto
{
    public class CartDto
    {
        public int CartItemId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalPrice => Quantity * PricePerItem;
        public string ProductUrl { get; set; }
    }
}
