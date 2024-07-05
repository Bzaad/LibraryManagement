using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IBookRepository
    {
        public void AddBook(Book book);
        public List<Book> GetBooks(bool loadCategory = false);
        public Book? GetBookById(int id, bool loadCategory = false);
        public void UpdateBook(int id, Book book);
        public void DeleteBook(int id);
        public List<Book> GetBooksByCategoryId(int categoryId);
    }
}
