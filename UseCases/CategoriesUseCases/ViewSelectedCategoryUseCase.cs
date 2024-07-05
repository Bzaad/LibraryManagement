using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category? Execute(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
