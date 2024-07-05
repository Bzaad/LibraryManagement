using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionsViewModel viewModel = new TransactionsViewModel();

            return View(viewModel);
        }

        public IActionResult Search(TransactionsViewModel viewModel) 
        {
            var transactions = TransactionRepo.Search(viewModel.UserName??string.Empty, viewModel.StartDate, viewModel.EndDate);

            viewModel.Transactions = transactions;

            return View("Index", viewModel);
        }
    }
}
