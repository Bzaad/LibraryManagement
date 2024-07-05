using Microsoft.AspNetCore.Mvc;
using LibraryApp.ViewModels;
using UseCases.Interfaces;
using CoreBusiness;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        public readonly IViewCategoriesUseCases _viewCategoriesUseCases;
        public readonly IGetBooksUseCase _getBooksUseCase;
        public readonly IGetSingleBookUseCase _getBookUseCase;
        public readonly IAddBookUseCase _addBookUseCase;
        public readonly IUpdateBookUseCase _updateBookUseCase;
        public readonly IDeleteBookUseCase _deleteBookUseCase;
        public readonly IGetBooksByCategoryUseCase _getBooksByCategoryUseCase;

        public BooksController
        (
            IViewCategoriesUseCases viewCategoriesUseCases,
            IGetBooksUseCase getBooksUseCase,
            IGetSingleBookUseCase getBookUseCase,
            IAddBookUseCase addBookUseCase, 
            IUpdateBookUseCase updateBookUseCase, 
            IDeleteBookUseCase deleteBookUseCase, 
            IGetBooksByCategoryUseCase getBooksByCategoryUseCase
        )
        {
            _viewCategoriesUseCases = viewCategoriesUseCases;
            _getBooksUseCase = getBooksUseCase;
            _getBookUseCase = getBookUseCase;
            _addBookUseCase = addBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _deleteBookUseCase = deleteBookUseCase;
            _getBooksByCategoryUseCase = getBooksByCategoryUseCase;
        }

        public IActionResult Index()
        {
            var books = _getBooksUseCase.Execute(loadCategory: true);
            return View(books);
        }

        public IActionResult Add() 
        {
            ViewBag.Action = "add";

            var bookViewModel = new BookViewModel
            {
                Categories = _viewCategoriesUseCases.Execute()
            };

            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Add(BookViewModel bookViewModel)
        {
            ViewBag.Action = "add";

            if (ModelState.IsValid)
            {
                _addBookUseCase.Execute(bookViewModel.Book);
                return RedirectToAction(nameof(Index));
            }

            bookViewModel.Categories = _viewCategoriesUseCases.Execute();
            return View(bookViewModel);

        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var bookViewModel = new BookViewModel
            {
                Book = _getBookUseCase.Execute(id) ?? new Book(), 
                Categories = _viewCategoriesUseCases.Execute()
            }; 
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel bookViewModel)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid) 
            {
                _updateBookUseCase.Execute(bookViewModel.Book.Id, bookViewModel.Book);
                return RedirectToAction(nameof(Index));
            }

            bookViewModel.Categories = _viewCategoriesUseCases.Execute();
            return View(bookViewModel);
        }

        public IActionResult Delete(int id) 
        {
           _deleteBookUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BooksByCategoryPartial(int categoryId)
        {
            var books = _getBooksByCategoryUseCase.Execute(categoryId);

            return PartialView("_Books", books);
        }
    }
}
