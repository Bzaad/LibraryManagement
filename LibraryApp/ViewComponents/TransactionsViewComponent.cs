using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases.TransactionUseCases;
using UseCases.Interfaces;

namespace LibraryApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent: ViewComponent
    {
        private readonly IGetByDateBorrowedAndUserUseCase _getByDateBorrowedAndUserUseCase;

        public TransactionsViewComponent(IGetByDateBorrowedAndUserUseCase getByDateBorrowedAndUserUseCase)
        {
            _getByDateBorrowedAndUserUseCase = getByDateBorrowedAndUserUseCase;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var transactions = _getByDateBorrowedAndUserUseCase.Execute(userName, DateTime.UtcNow);

            return View(transactions);
        }
    }
}
