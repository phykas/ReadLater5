using Microsoft.EntityFrameworkCore;
using ReadLater.Bookmarks.Application.Bookmarks;
using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Domain;
using ReadLater.Bookmarks.EntityFramework.Entities;
using ReadLater.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.EntityFramework
{
    public class BookmarksRepository : IBookmarksRepository
    {
        private ReadLaterDataContext _readLaterDataContext;
        private readonly IBookmarksMapperService _mapperService;
        private readonly IClock _clock;

        public BookmarksRepository(ReadLaterDataContext readLaterDataContext, IBookmarksMapperService mapperService, IClock clock)
        {
            _readLaterDataContext = readLaterDataContext;
            _mapperService = mapperService;
            _clock = clock;
        }

        public async Task<BookmarkDto> CreateAsync(BookmarkDto bookmark)
        {
            var entity = _mapperService.Map<BookmarkDto, Bookmark>(bookmark);
            entity.CreateDate = _clock.Now;
            var bookmarkEntity = _readLaterDataContext.Add(entity);
            await _readLaterDataContext.SaveChangesAsync();
            return _mapperService
                .Map<Bookmark, BookmarkDto>(bookmarkEntity.Entity);
        }

        public async Task<IEnumerable<BookmarkDto>> GetAsync()
        {
            return _mapperService
                .Map<IEnumerable<Bookmark>, IEnumerable<BookmarkDto>>(await _readLaterDataContext.Bookmarks
                .Include(e => e.Category).ToListAsync());
        }

        public async Task<BookmarkDto> GetAsync(int id)
        {
            return _mapperService
                .Map<Bookmark, BookmarkDto>(await _readLaterDataContext.Bookmarks.Include(e => e.Category)
                .Where(c => c.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<BookmarkDto>> GetByUserIdAsync(string userId)
        {
            return _mapperService
                .Map<IEnumerable<Bookmark>, IEnumerable<BookmarkDto>>(await _readLaterDataContext.Bookmarks
                .Include(e => e.Category).Where(c => c.UserId == userId).ToListAsync());
        }

        public async Task<BookmarkDto> GetAsync(string url)
        {
            return _mapperService
                .Map<Bookmark, BookmarkDto>(await _readLaterDataContext.Bookmarks
                .Include(e => e.Category).Where(c => c.Url == url).FirstOrDefaultAsync());
        }

        public Task UpdateAsync(BookmarkDto bookmark)
        {
            _readLaterDataContext.Update(_mapperService.Map<BookmarkDto, Bookmark>(bookmark));
            return _readLaterDataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BookmarkDto bookmarkDto)
        {
            var bookmark = await _readLaterDataContext.Bookmarks.FirstOrDefaultAsync(e => e.Id == bookmarkDto.Id);
            if (bookmark == null)
            {
                return;
            }
            _readLaterDataContext.Bookmarks.Remove(bookmark);
            await _readLaterDataContext.SaveChangesAsync();
        }

        public async Task TrackBookmarkUsageAsync(int id)
        {
            var bookmark = await _readLaterDataContext.Bookmarks.FirstOrDefaultAsync(e => e.Id == id);
            bookmark.ClickCount++;
            _readLaterDataContext.Update(bookmark);
            await _readLaterDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookmarkDto>> GetMostVisitedAsync(int count)
        {
            return _mapperService
                           .Map<IEnumerable<Bookmark>, IEnumerable<BookmarkDto>>(await _readLaterDataContext.Bookmarks
                           .Include(e => e.Category).OrderByDescending(e => e.ClickCount).Take(count).ToListAsync());
        }
    }
}
