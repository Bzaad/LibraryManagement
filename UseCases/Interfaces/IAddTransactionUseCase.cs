namespace UseCases.Interfaces
{
    public interface IAddTransactionUseCase
    {
        void Execute(string bookName, int bookId, string userName, int userId, int beforeAvilable, int afterAvilable);
    }
}