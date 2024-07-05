using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IGetBooksByCategoryUseCase
    {
        List<Book> Execute(int categoryId);
    }
}