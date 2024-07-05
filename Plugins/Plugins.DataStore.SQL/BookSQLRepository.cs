using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class BookSQLRepository : IBookRepository
    {
        private readonly LibraryContext _db;

        public BookSQLRepository(LibraryContext db) 
        {
            _db = db;
        }

        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _db.Books.Find(id);

            if (book == null) return;

            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public Book? GetBookById(int id, bool loadCategory = false)
        {
            if (loadCategory)
                return _db.Books
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.Id == id);
            else
                return _db.Books
                    .FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooks(bool loadCategory = false)
        {
            if (loadCategory)
                return _db.Books.Include(x => x.Category)
                    .OrderBy(x => x.CategoryId).ToList();
            else 
                return _db.Books.OrderBy(x => x.CategoryId).ToList();
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
        {
            return _db.Books.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateBook(int id, Book book)
        {
            if (id != book.Id) return;

            var b = _db.Books.Find(id);

            if (b == null) return;

            b.CategoryId = book.CategoryId;
            b.Name = book.Name;
            b.Description = book.Description;
            b.AvailableCopies = book.AvailableCopies;

            _db.SaveChanges();
                
        }
    }
}
