using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IGetByDateBorrowedAndUserUseCase
    {
        IEnumerable<Transaction> Execute(string userName, DateTime date);
    }
}