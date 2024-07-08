using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionSQLRepository : ITransactionRepository
    {
        private readonly LibraryContext _db;

        public TransactionSQLRepository(LibraryContext db)
        {
            _db = db;
        }

        public void Add(string bookName, int bookId, string userName, int userId, int beforeAvilable, int afterAvilable)
        {
            var transaction = new Transaction
            {
                BookName = bookName,
                BookId = bookId,
                UserName = userName,
                UserId = userId,
                DateBorrowed = DateTime.UtcNow,
                DateShouldBeReturned = DateTime.UtcNow.AddDays(7)
            };

            _db.Transactions.Add(transaction);

            _db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDateBorrowedAndUser(string userName, DateTime date)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return _db.Transactions.Where(x => x.DateBorrowed.Date == date.Date);
            }
            else
            {
                return _db.Transactions.Where(x => EF.Functions.Like(x.UserName, $"%{userName}%") && x.DateBorrowed.Date == date.Date);

            }
        }

        public IEnumerable<Transaction> Search(string userName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return _db.Transactions.Where(
                    x => x.DateBorrowed.Date >= startDate.Date &&
                    x.DateBorrowed.Date <= endDate.Date);
            }
            else
            {
                return _db.Transactions.Where(
                    x => EF.Functions.Like(x.UserName, $"%{userName}%") && 
                    x.DateBorrowed.Date >= startDate.Date &&
                    x.DateBorrowed.Date <= endDate.Date);

            }
        }
    }
}
