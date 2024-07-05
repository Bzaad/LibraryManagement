using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IEditCategoryUseCase
    {
        void Execute(int categoryId, Category category);
    }
}