using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IViewCategoriesUseCases
    {
        IEnumerable<Category> Execute();
    }
}