using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface ISearchTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string userName, DateTime startDate, DateTime endDate);
    }
}