using HmhLesson06lab.Data;
using Microsoft.AspNetCore.Mvc;

namespace HmhLesson06lab.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = HmhDataStore.GetHotProducts();
            return View(hotProducts);
        }
    }
}
