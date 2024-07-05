using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.BooksUseCases
{
    public class GetBooksByCategoryUseCase : IGetBooksByCategoryUseCase
    {
        private readonly IBookRepository _bookRepository;


        public GetBooksByCategoryUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> Execute(int categoryId)
        {
            return _bookRepository.GetBooksByCategoryId(categoryId);
        }
    }
}
