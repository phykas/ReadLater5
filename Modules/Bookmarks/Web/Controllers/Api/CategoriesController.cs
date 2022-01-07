using Microsoft.AspNetCore.Mvc;
using ReadLater.Bookmarks.Application;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var categories = await _categoryService.SearchAsync(query);
            return Ok(categories);
        }
    }
}
