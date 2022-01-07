using Microsoft.AspNetCore.Mvc;
using ReadLater.Bookmarks.Application.Bookmarks;
using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Domain;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly IBookmarksService _bookmarksService;
        private readonly IBookmarksMapperService _bookmarksMapper;

        public BookmarksController(IBookmarksService bookmarksService, IBookmarksMapperService bookmarksMapper)
        {
            _bookmarksService = bookmarksService;
            _bookmarksMapper = bookmarksMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GotoLinkAsync(int? id)
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

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _bookmarksService.GetAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int? id)
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
            return View(bookmark);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(BookmarkRequest bookmark)
        {
            if (ModelState.IsValid)
            {
                await _bookmarksService.CreateAsync(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int? id)
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

            return View(_bookmarksMapper.Map<BookmarkDto, BookmarkRequest>(bookmark));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(BookmarkRequest bookmark)
        {
            if (ModelState.IsValid)
            {
                await _bookmarksService.UpdateAsync(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
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

            return View(bookmark);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            BookmarkDto bookmark = await _bookmarksService.GetAsync(id);
            await _bookmarksService.DeleteAsync(bookmark);
            return RedirectToAction("Index");
        }
    }
}
