namespace HmhLesson08Lab.Models
{
    public class HmhProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
