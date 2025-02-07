﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(int categoryId, Category category)
        {
            _categoryRepository.UpdateCategory(categoryId, category);
        }
    }
}
