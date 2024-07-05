using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewCategoriesUseCases : IViewCategoriesUseCases
    {
        private readonly ICategoryRepository _categoryRepository;
        public ViewCategoriesUseCases(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
