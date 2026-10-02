using Microsoft.AspNetCore.Mvc;
using HmhBaiThucHanh03.Models;

namespace HmhBaiThucHanh03.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
