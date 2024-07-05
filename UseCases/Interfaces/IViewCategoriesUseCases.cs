using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IViewCategoriesUseCases
    {
        IEnumerable<Category> Execute();
    }
}