using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IGetSingleBookUseCase
    {
        Book? Execute(int id, bool loadCategory = false);
    }
}