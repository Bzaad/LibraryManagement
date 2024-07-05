using CoreBusiness;

using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.TransactionUseCases
{
    public class SearchTransactionUseCase : ISearchTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public SearchTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string userName, DateTime startDate, DateTime endDate)
        {
            return _transactionRepository.Search(userName, startDate, endDate);
        }
    }
}
