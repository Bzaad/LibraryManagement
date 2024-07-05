using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IUpdateBookUseCase
    {
        void Execute(int id, Book book);
    }
}