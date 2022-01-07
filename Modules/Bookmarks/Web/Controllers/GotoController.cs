using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadLater.Bookmarks.Application.Bookmarks;
using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Domain;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    [AllowAnonymous]
    public class GotoController : Controller
    {
        private readonly IBookmarksService _bookmarksService;
        private readonly IBookmarksMapperService _bookmarksMapper;

        public GotoController(IBookmarksService bookmarksService, IBookmarksMapperService bookmarksMapper)
        {
            _bookmarksService = bookmarksService;
            _bookmarksMapper = bookmarksMapper;
        }

        [HttpGet]
        [Route("{controller}/{id}", Name = "Goto")]
        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            BookmarkDto bookmark = await _bookmarksService.GetAsync(id.Value);

            if (bookmark == null)
            {
                return NotFound();
            }

            await _bookmarksService.TrackBookmarkUsageAsync(bookmark.Id);

            return Redirect(bookmark.Url);
        }
    }
}
