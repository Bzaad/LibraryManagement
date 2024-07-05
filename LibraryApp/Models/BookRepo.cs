namespace LibraryApp.Models
{
    public class BookRepo
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book { Id = 1, CategoryId = 1, Name = "A Farewell to Arms", Description= "A good book!", AvailableCopies = 100 },
            new Book { Id = 2, CategoryId = 1, Name = "the hitchhiker's guide to the galaxy", Description = "Fantastic", AvailableCopies = 200 },
            new Book { Id = 3, CategoryId = 2, Name = "The Language Instinct", AvailableCopies = 300 },
            new Book { Id = 4, CategoryId = 2, Name = "A Brief History of Time", AvailableCopies = 300 }
        };

        public static void AddBook(Book book)
        {
            if(_books != null && _books.Count() > 0)
            {
                var maxId = BookRepo._books.Max(x => x.Id);
                book.Id = maxId + 1;
            }
            else
            {
                book.Id = 1;
            }

            if (_books == null) _books = new List<Book>();
            BookRepo._books.Add(book);
        }

        public static List<Book> GetBooks(bool loadCategory = false)
        {
            if (_books != null && _books.Count > 0 && loadCategory)
            {

                _books.ForEach(book =>
                {
                    if (book.CategoryId.HasValue)
                        book.Category = CatRepo.GetCategoryById(book.CategoryId.Value);
                });
            }

            return _books;

        }

        public static Book? GetBookById(int id, bool loadCategory = false)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);


            if (book != null)
            {
                book =  new Book
                {
                    Id = book.Id,
                    Name = book.Name,
                    Description = book.Description,
                    AvailableCopies = book.AvailableCopies,
                    CategoryId = book.CategoryId
                };
            }

            if (loadCategory && book.CategoryId.HasValue)
            {
                book.Category = CatRepo.GetCategoryById(book.CategoryId.Value);
            }

            return book;
        }

        public static void UpdateBook(int id, Book book)
        {
            if (id != book.Id) return;

            var bookToUpdate = _books.FirstOrDefault(x => x.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Name = book.Name;
                bookToUpdate.Description = book.Description;
                bookToUpdate.AvailableCopies = book.AvailableCopies;
                bookToUpdate.CategoryId = book.CategoryId;
            }
        }

        public static void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public static List<Book> GetBooksByCategoryId(int categoryId)
        {
            var books = _books.Where(book => book.CategoryId == categoryId);

            if (books != null)
                return books.ToList();
            else 
                return new List<Book>();
        }
    }
}
