using HmhLesson06.Models;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson06.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
       public IViewComponentResult Invoke(int? n)
        {
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "Books", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Clothing", IsActive = false },
                new Category { CategoryId = 4, CategoryName = "Home & Kitchen", IsActive = true }
            };

            n = n ?? 0;
            var search = categories.Where(x => x.CategoryId > n).ToList();
            return View(search);
        }
    }
}
