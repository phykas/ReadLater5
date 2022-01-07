using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Domain;
using ReadLater.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadLater.Bookmarks.Application.Bookmarks
{
    public class BookmarksService : IBookmarksService
    {
        private readonly IBookmarksRepository _bookmarksRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookmarksMapperService _mapperService;

        public BookmarksService(IBookmarksRepository bookmarksRepository, ICategoryRepository categoryRepository,
            IBookmarksMapperService mapperService)
        {
            _bookmarksRepository = bookmarksRepository;
            _categoryRepository = categoryRepository;
            _mapperService = mapperService;
        }

        public async Task<BookmarkDto> CreateAsync(BookmarkCreateRequest bookmark)
        {
            var category = await _categoryRepository.GetAsync(bookmark.Category);
            var bookmarkDto = _mapperService.Map<BookmarkCreateRequest, BookmarkDto>(bookmark);
            bookmarkDto.CategoryId = category?.Id;
            if (category == null)
            {
                bookmarkDto.Category = new CategoryDto()
                {
                    Name = bookmark.Category
                };
            }

            return await _bookmarksRepository.CreateAsync(bookmarkDto);
        }

        public Task DeleteAsync(BookmarkDto bookmark)
        {
            return _bookmarksRepository.DeleteAsync(bookmark);
        }

        public Task<IEnumerable<BookmarkDto>> GetAsync()
        {
            return _bookmarksRepository.GetAsync();
        }

        public Task<BookmarkDto> GetAsync(int id)
        {
            return _bookmarksRepository.GetAsync(id);
        }

        public Task<BookmarkDto> GetAsync(string name)
        {
            return _bookmarksRepository.GetAsync(name);
        }

        public async Task UpdateAsync(BookmarkEditRequest bookmark)
        {
            var category = await _categoryRepository.GetAsync(bookmark.Category);
            var bookmarkDto = _mapperService.Map<BookmarkEditRequest, BookmarkDto>(bookmark);
            bookmarkDto.CategoryId = category?.Id;
            if (category == null)
            {
                bookmarkDto.Category = new CategoryDto()
                {
                    Name = bookmark.Category
                };
            }
            await _bookmarksRepository.UpdateAsync(bookmarkDto);
        }
    }
}
