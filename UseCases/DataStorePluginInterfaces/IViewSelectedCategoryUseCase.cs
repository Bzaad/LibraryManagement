using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryId);
    }
}