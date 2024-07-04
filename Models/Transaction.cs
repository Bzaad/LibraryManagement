namespace LibraryApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime DateBorrowed { get; set; }
        public DateTime DateShouldBeReturned { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}
