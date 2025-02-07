﻿using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

    }
}
