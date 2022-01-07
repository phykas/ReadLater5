using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadLater.Bookmarks.Application.Bookmarks;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    [AllowAnonymous]
    public class MostVisitedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookmarksService _bookmarksService;

        public MostVisitedController(ILogger<HomeController> logger, IBookmarksService bookmarksService)
        {
            _logger = logger;
            _bookmarksService = bookmarksService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var topFiveBookmarks = await _bookmarksService.GetMostVisitedAsync(5);
            return View(topFiveBookmarks);
        }
    }
}
