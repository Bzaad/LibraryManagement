using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.BooksUseCases;
using UseCases.Interfaces;

namespace LibraryApp.Controllers
{
    [Authorize(Policy = "LibraryUser")]
    public class UserConsoleController : Controller
    {
        public readonly IViewCategoriesUseCases _viewCategoriesUseCases;
        public readonly IGetSingleBookUseCase _getSingleBookUseCase;
        public readonly IUpdateBookUseCase _updateBookUseCase;
        public readonly IAddTransactionUseCase _addTransactionUseCase;
        public readonly IGetBooksByCategoryUseCase _getBooksByCategoryUseCase;

        public UserConsoleController
        (
            IViewCategoriesUseCases viewCategoriesUseCases, 
            IGetSingleBookUseCase getSingleBookUseCase, 
            IUpdateBookUseCase updateBookUseCase, 
            IAddTransactionUseCase addTransactionUseCase, 
            IGetBooksByCategoryUseCase getBooksByCategoryUseCase
        )
        {
            _viewCategoriesUseCases = viewCategoriesUseCases;
            _getSingleBookUseCase = getSingleBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _addTransactionUseCase = addTransactionUseCase;
            _getBooksByCategoryUseCase = getBooksByCategoryUseCase;
        }
        public IActionResult Index()
        {
            var userConsoleViewModel = new UserConsoleViewModel
            {
                Categories = _viewCategoriesUseCases.Execute()
            };
            return View(userConsoleViewModel);
        }

        public IActionResult SelectBookPartial(int bookId) 
        {
            var book = _getSingleBookUseCase.Execute(bookId);
            return PartialView("_SelectBook", book);
        }

        public IActionResult BorrowBookPartial(int bookId)
        {
            var book = _getSingleBookUseCase.Execute(bookId);
            return PartialView("_BorrowBook", book);
        }

        public IActionResult Borrow(UserConsoleViewModel userConsoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = _getSingleBookUseCase.Execute(userConsoleViewModel.SelectedBookId);
                if (book != null)
                {
                   _addTransactionUseCase.Execute(book.Name, book.Id, "user1", 1, book.AvailableCopies!.Value, book.AvailableCopies.Value - 1);

                    book.AvailableCopies--;
                    _updateBookUseCase.Execute(userConsoleViewModel.SelectedBookId, book);
                }
            }

            var bookView = _getSingleBookUseCase.Execute(userConsoleViewModel.SelectedBookId);
            userConsoleViewModel.SelectedCategoryId = bookView?.CategoryId ?? 0;
            userConsoleViewModel.Categories = _viewCategoriesUseCases.Execute(); 

            return View("Index", userConsoleViewModel);
        }
        public IActionResult BooksByCategoryPartial(int categoryId)
        {
            var books = _getBooksByCategoryUseCase.Execute(categoryId);

            return PartialView("_Books", books);
        }
    }
}
