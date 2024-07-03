using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class UserConsoleController : Controller
    {
        public IActionResult Index()
        {
            var userConsoleViewModel = new UserConsoleViewModel
            {
                Categories = CatRepo.GetCategories()
            };
            return View(userConsoleViewModel);
        }

        public IActionResult SelectBookPartial(int bookId) 
        {
            var book = BookRepo.GetBookById(bookId);
            return PartialView("_SelectBook", book);
        }
    }
}
