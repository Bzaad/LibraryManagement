using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.ViewModels;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var books = BookRepo.GetBooks(loadCategory: true);
            return View(books);
        }

        public IActionResult Add() 
        {
            ViewBag.Action = "add";

            var bookViewModel = new BookViewModel
            {
                Categories = CatRepo.GetCategories()
            };

            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Add(BookViewModel bookViewModel)
        {
            ViewBag.Action = "add";

            if (ModelState.IsValid)
            {
                BookRepo.AddBook(bookViewModel.Book);
                return RedirectToAction(nameof(Index));
            }

            bookViewModel.Categories = CatRepo.GetCategories();
            return View(bookViewModel);

        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var bookViewModel = new BookViewModel
            {
                Book = BookRepo.GetBookById(id) ?? new Book(), 
                Categories = CatRepo.GetCategories()
            }; 
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel bookViewModel)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid) 
            {
                BookRepo.UpdateBook(bookViewModel.Book.Id, bookViewModel.Book);
                return RedirectToAction(nameof(Index));
            }

            bookViewModel.Categories = CatRepo.GetCategories();
            return View(bookViewModel);
        }

        public IActionResult Delete(int id) 
        {
           BookRepo.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BooksByCategoryPartial(int categoryId)
        {
            var books = BookRepo.GetBooksByCategoryId(categoryId);

            return PartialView("_Books", books);
        }
    }
}
