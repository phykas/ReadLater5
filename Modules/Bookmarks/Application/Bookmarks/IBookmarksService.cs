using ReadLater.Bookmarks.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application.Bookmarks
{
    public interface IBookmarksService
    {
        Task<BookmarkDto> CreateAsync(BookmarkCreateRequest bookmark);
        Task<IEnumerable<BookmarkDto>> GetAsync();
        Task<BookmarkDto> GetAsync(int id);
        Task<BookmarkDto> GetAsync(string name);
        Task UpdateAsync(BookmarkEditRequest bookmark);
        Task DeleteAsync(BookmarkDto bookmark);
    }
}
