namespace HmhLesson06lab.Models
{
    public class HmhProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsNew { get; set; }
        public bool IsHot { get; set; }
    }

    public class Product : HmhProduct
    {
    }
}
