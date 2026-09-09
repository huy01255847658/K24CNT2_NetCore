using HmhLesson06lab.Models;

namespace HmhLesson06lab.Data
{
    public static class HmhDataStore
    {
        public static List<HmhCategory> Categories { get; } = new List<HmhCategory>
        {
            new HmhCategory { Id = 1, Name = "Áo dài" },
            new HmhCategory { Id = 2, Name = "Áo đông" },
            new HmhCategory { Id = 3, Name = "Túi xách" },
            new HmhCategory { Id = 4, Name = "Đồng hồ" },
            new HmhCategory { Id = 5, Name = "Ví da" },
            new HmhCategory { Id = 6, Name = "Thắt lưng da" },
            new HmhCategory { Id = 7, Name = "Tủ lạnh" },
            new HmhCategory { Id = 8, Name = "Tivi" },
            new HmhCategory { Id = 9, Name = "Quạt điện" },
            new HmhCategory { Id = 10, Name = "Lò sưởi" }
        };

        public static List<HmhProduct> Products { get; } = new List<HmhProduct>
        {
            new HmhProduct
            {
                Id = 1,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = true,
                IsHot = false
            },
            new HmhProduct
            {
                Id = 2,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = true,
                IsHot = false
            },
            new HmhProduct
            {
                Id = 3,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = true,
                IsHot = false
            },

            new HmhProduct
            {
                Id = 4,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = false,
                IsHot = true
            },
            new HmhProduct
            {
                Id = 5,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = false,
                IsHot = true
            },
            new HmhProduct
            {
                Id = 6,
                Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                Price = 2450000,
                Image = "/images/noi-com-dien.png",
                CategoryId = 7,
                IsNew = false,
                IsHot = true
            }
        };

        public static List<HmhProduct> GetNewProducts() =>
            Products.Where(p => p.IsNew).ToList();

        public static List<HmhProduct> GetHotProducts() =>
            Products.Where(p => p.IsHot).ToList();
    }
}
