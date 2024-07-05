using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.TransactionUseCases
{
    public class AddTransactionUseCase : IAddTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public AddTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Execute(string bookName, int bookId, string userName, int userId, int beforeAvilable, int afterAvilable)
        {
            _transactionRepository.Add(bookName, bookId, userName, userId, beforeAvilable, afterAvilable);
        }
    }
}
