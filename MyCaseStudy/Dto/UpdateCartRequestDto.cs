namespace MyCaseStudy.Dto
{
    public class UpdateCartRequestDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsIncrement { get; set; }
    }
}
