using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IGetBooksUseCase
    {
        List<Book> Execute(bool loadCategory = false);
    }
}