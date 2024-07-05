using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}