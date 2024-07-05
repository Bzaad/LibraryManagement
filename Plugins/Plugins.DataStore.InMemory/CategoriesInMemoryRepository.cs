using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {
        public CategoriesInMemoryRepository()
        {
        }

        private List<Category> _categories = new List<Category>
        {
            new Category { Id =1, Name = "Science Fiction", Description = "Science fiction category" },
            new Category { Id = 2, Name = "Romance", Description = "Romance category" },
            new Category { Id = 3, Name = "Something", Description = "Something category" }
        };

        public void AddCategory(Category category)
        {
            if (_categories != null && _categories.Count() > 0)
            {
                category.Id = _categories.Max(x => x.Id) + 1;
            }
            else
            {
                category.Id = 1;
            }

            if (_categories == null) _categories = new List<Category>();

            _categories.Add(category);
        }

        public IEnumerable<Category> GetCategories() => _categories;

        public Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCategory(int id, Category category)
        {
            if (id != category.Id) return;
            var catToUpdate = GetCategoryById(id);
            if (catToUpdate != null)
            {
                catToUpdate.Name = category.Name;
                catToUpdate.Description = category.Description;
            }
        }

        public void DeleteCategory(int id)
        {
            var catToDelete = _categories.FirstOrDefault(x => x.Id == id);

            if (catToDelete != null)
                _categories.Remove(catToDelete);
        }
    }
}
