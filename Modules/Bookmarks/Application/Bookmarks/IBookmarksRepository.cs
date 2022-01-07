using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application.Bookmarks
{
    public interface IBookmarksRepository
    {
        Task<BookmarkDto> CreateAsync(BookmarkDto bookmark);
        Task<IEnumerable<BookmarkDto>> GetAsync();
        Task<BookmarkDto> GetAsync(int id);
        Task<BookmarkDto> GetAsync(string url);
        Task UpdateAsync(BookmarkDto bookmark);
        Task DeleteAsync(BookmarkDto bookmark);
        Task<IEnumerable<BookmarkDto>> GetByUserIdAsync(string userId);
        Task TrackBookmarkUsageAsync(int id);
        Task<IEnumerable<BookmarkDto>> GetMostVisitedAsync(int count);
    }
}
