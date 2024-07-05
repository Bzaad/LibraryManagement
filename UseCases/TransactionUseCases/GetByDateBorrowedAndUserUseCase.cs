using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.TransactionUseCases
{
    public class GetByDateBorrowedAndUserUseCase : IGetByDateBorrowedAndUserUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetByDateBorrowedAndUserUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string userName, DateTime date)
        {
            return _transactionRepository.GetByDateBorrowedAndUser(userName, date);
        }
    }
}
