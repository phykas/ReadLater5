using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Authentication;
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
        private readonly ICurrentUserService _currentUserService;

        public BookmarksService(IBookmarksRepository bookmarksRepository, ICategoryRepository categoryRepository,
            IBookmarksMapperService mapperService, ICurrentUserService currentUser)
        {
            _bookmarksRepository = bookmarksRepository;
            _categoryRepository = categoryRepository;
            _mapperService = mapperService;
            _currentUserService = currentUser;
        }

        public async Task<IEnumerable<BookmarkDto>> GetAsync()
        {
            var currentUser = await _currentUserService.Retrieve();
            return await _bookmarksRepository.GetByUserIdAsync(currentUser.Id);
        }

        public Task<BookmarkDto> GetAsync(int id)
        {
            return _bookmarksRepository.GetAsync(id);
        }

        public Task<BookmarkDto> GetAsync(string url)
        {
            return _bookmarksRepository.GetAsync(url);
        }

        public async Task<BookmarkDto> CreateAsync(BookmarkCreateRequest bookmark)
        {
            var currentUser = await _currentUserService.Retrieve();
            var category = await _categoryRepository.GetAsync(currentUser.Id, bookmark.Category);
            var bookmarkDto = _mapperService.Map<BookmarkCreateRequest, BookmarkDto>(bookmark);
            bookmarkDto.CategoryId = category?.Id;
            bookmarkDto.UserId = currentUser.Id;
            if (category == null)
            {
                bookmarkDto.Category = new CategoryDto()
                {
                    Name = bookmark.Category,
                    UserId = bookmarkDto.UserId
                };
            }

            return await _bookmarksRepository.CreateAsync(bookmarkDto);
        }

        public async Task DeleteAsync(BookmarkDto bookmark)
        {
            var currentUser = await _currentUserService.Retrieve();
            bookmark.UserId = currentUser.Id;
            await _bookmarksRepository.DeleteAsync(bookmark);
        }

        public async Task UpdateAsync(BookmarkEditRequest bookmark)
        {
            var currentUser = await _currentUserService.Retrieve();
            var category = await _categoryRepository.GetAsync(currentUser.Id, bookmark.Category);
            var bookmarkDto = _mapperService.Map<BookmarkEditRequest, BookmarkDto>(bookmark);
            bookmarkDto.CategoryId = category?.Id;
            bookmarkDto.UserId = currentUser.Id;
            if (category == null)
            {
                bookmarkDto.Category = new CategoryDto()
                {
                    Name = bookmark.Category,
                    UserId = bookmarkDto.UserId
                };
            }
            await _bookmarksRepository.UpdateAsync(bookmarkDto);
        }
    }
}
