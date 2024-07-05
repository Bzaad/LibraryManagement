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

        public IActionResult BorrowBookPartial(int bookId)
        {
            var book = BookRepo.GetBookById(bookId);
            return PartialView("_BorrowBook", book);
        }

        public IActionResult Borrow(UserConsoleViewModel userConsoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = BookRepo.GetBookById(userConsoleViewModel.SelectedBookId);
                if (book != null)
                {
                    TransactionRepo.Add(book.Name, book.Id, "user1", 1, book.AvailableCopies!.Value, book.AvailableCopies.Value - 1);

                    book.AvailableCopies--;
                    BookRepo.UpdateBook(userConsoleViewModel.SelectedBookId, book);
                }
            }

            var bookView = BookRepo.GetBookById(userConsoleViewModel.SelectedBookId);
            userConsoleViewModel.SelectedCategoryId = bookView?.CategoryId ?? 0;
            userConsoleViewModel.Categories = CatRepo.GetCategories(); 

            return View("Index", userConsoleViewModel);
        }
    }
}
