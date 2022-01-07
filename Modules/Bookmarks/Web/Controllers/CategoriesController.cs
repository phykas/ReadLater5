using Microsoft.AspNetCore.Mvc;
using ReadLater.Bookmarks.Application;
using ReadLater.Bookmarks.Domain;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _categoryService.GetForCurrentUserAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CategoryDto category = await _categoryService.GetAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            CategoryDto category = await _categoryService.GetAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            CategoryDto category = await _categoryService.GetAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            CategoryDto category = await _categoryService.GetAsync(id);
            await _categoryService.DeleteAsync(category);
            return RedirectToAction("Index");
        }
    }
}
