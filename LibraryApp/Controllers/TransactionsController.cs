using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using LibraryApp.ViewModels;

namespace LibraryApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionUseCase _searchTransactionUseCase;

        public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
        {
            _searchTransactionUseCase = searchTransactionUseCase;
        }

        public IActionResult Index()
        {
            TransactionsViewModel viewModel = new TransactionsViewModel();

            return View(viewModel);
        }

        public IActionResult Search(TransactionsViewModel viewModel) 
        {
            var transactions = _searchTransactionUseCase.Execute(viewModel.UserName??string.Empty, viewModel.StartDate, viewModel.EndDate);

            viewModel.Transactions = transactions;

            return View("Index", viewModel);
        }
    }
}
