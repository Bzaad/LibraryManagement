using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class GetBooksUseCase : IGetBooksUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> Execute(bool loadCategory = false)
        {
            return _bookRepository.GetBooks(loadCategory);
        }
    }
}
