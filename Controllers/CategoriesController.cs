using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CatRepo.GetCategories();

            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            var category = CatRepo.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CatRepo.UpdateCategory(category.Id, category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CatRepo.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CatRepo.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
