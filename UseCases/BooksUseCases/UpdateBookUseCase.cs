using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class UpdateBookUseCase : IUpdateBookUseCase
    {
        public readonly IBookRepository _bookRepository;

        public UpdateBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(int id, Book book)
        {
            _bookRepository.UpdateBook(id, book);
        }
    }
}
