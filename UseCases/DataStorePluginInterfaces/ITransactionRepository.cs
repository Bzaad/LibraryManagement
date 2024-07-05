using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> GetByDateBorrowedAndUser(string userName, DateTime date);

        public IEnumerable<Transaction> Search(string userName, DateTime startDate, DateTime endDate);

        public void Add(string bookName, int bookId, string userName, int userId, int beforeAvilable, int afterAvilable);
    }
}
