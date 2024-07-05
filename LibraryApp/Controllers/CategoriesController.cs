using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using UseCases.DataStorePluginInterfaces;

namespace LibraryApp.Controllers
{
    public class CategoriesController : Controller
    {
        public readonly IViewCategoriesUseCases _viewCategoryUseCases;
        public readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;
        public readonly IAddCategoryUseCase _addCategoryUseCase;
        public readonly IDeleteCategoryUseCase _deleteCategoryUseCase;
        public readonly IEditCategoryUseCase _editCategoryUseCase;

        public CategoriesController
        (
            IViewCategoriesUseCases viewCategoryUseCases,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
            IAddCategoryUseCase addCategoryUseCase, 
            IDeleteCategoryUseCase deleteCategoryUseCase, 
            IEditCategoryUseCase editCategoryUseCase

        )
        {
            _viewCategoryUseCases = viewCategoryUseCases;
            _viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            _addCategoryUseCase = addCategoryUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
            _editCategoryUseCase = editCategoryUseCase;
        }

        public IActionResult Index()
        {
            var categories = _viewCategoryUseCases.Execute();

            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

            var category = _viewSelectedCategoryUseCase.Execute(id.HasValue ? id.Value : 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid)
            {
                _editCategoryUseCase.Execute(category.Id, category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            ViewBag.Action = "add";

            if (ModelState.IsValid)
            {
                _addCategoryUseCase.Execute(category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _deleteCategoryUseCase.Execute(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
