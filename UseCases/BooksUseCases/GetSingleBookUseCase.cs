using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class GetSingleBookUseCase : IGetSingleBookUseCase
    {
        public readonly IBookRepository _bookRepository;

        public GetSingleBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book? Execute(int id, bool loadCategory = false)
        {
            return _bookRepository.GetBookById(id, loadCategory);
        }
    }
}
