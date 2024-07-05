using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;

namespace LibraryApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionRepo.GetByDateBorrowedAndUser(userName, DateTime.UtcNow);

            return View(transactions);
        }
    }
}
