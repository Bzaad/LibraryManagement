namespace LibraryApp.Models
{
    public static class CatRepo
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id =1, Name = "Science Fiction", Description = "Science fiction category" },
            new Category { Id = 2, Name = "Romance", Description = "Romance category" },
            new Category { Id = 3, Name = "Something", Description = "Something category" }
        };

        public static void AddCategory(Category category)
        {
            category.Id = _categories.Max(x => x.Id) + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public static void UpdateCategory(int id, Category category)
        {
            if (id != category.Id) return;
            var catToUpdate = GetCategoryById(id);
            if (catToUpdate != null)
            {
                catToUpdate.Name = category.Name;
                catToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int id)
        {
            var catToDelete = _categories.FirstOrDefault(x => x.Id == id);

            if(catToDelete != null)
                _categories.Remove(catToDelete);
        }
    }
}
