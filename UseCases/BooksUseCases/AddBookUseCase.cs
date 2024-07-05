using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class AddBookUseCase : IAddBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public AddBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(Book book)
        {
            _bookRepository.AddBook(book);
        }
    }
}
