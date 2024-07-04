namespace LibraryApp.Models
{
    public class TransactionRepo
    {
        public static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDateBorrowedAndUser(string userName, DateTime date)
        {
            if (string.IsNullOrEmpty(userName)) 
            {
                return transactions.Where(x => x.DateBorrowed.Date.Equals(date.Date));
            }
            else
            {
                return transactions.Where(x => x.UserName.ToLower().Contains(userName.ToLower()) &&
                x.DateBorrowed.Date.Equals(date.Date));
            }
        }

        public static IEnumerable<Transaction> Search(string userName, DateTime startDate, DateTime endDate) 
        {
            if (string.IsNullOrEmpty(userName))
            {
                return transactions.Where(x => x.DateBorrowed >= startDate.Date && x.DateBorrowed <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return transactions.Where(x => x.UserName.ToLower().Contains(userName.ToLower()) &&
                x.DateBorrowed >= startDate.Date && x.DateBorrowed < endDate.Date.AddDays(1).Date);
            }
        }

        public static void Add(string bookName, int bookId, string userName, int userId, int beforeAvilable, int afterAvilable)
        {

            var transaction = new Transaction
            {
                BookId = bookId,
                BookName = bookName,
                UserId = userId,
                UserName = userName,
                DateBorrowed = DateTime.UtcNow,
                DateShouldBeReturned = DateTime.UtcNow.AddDays(7),

            };

            if (transactions != null && transactions.Count > 0)
            {
                transaction.Id = transactions.Max(x => x.Id) + 1;
            }
            else
            {
                transaction.Id = 1;
            }
            
            transactions.Add(transaction);
        }
    }
}
