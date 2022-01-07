using AutoMapper;
using ReadLater.Bookmarks.Domain;
using ReadLater.Bookmarks.EntityFramework.Entities;

namespace Readlater.Bookmarks.Automapper
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<BookmarkDto, Bookmark>();
            CreateMap<Bookmark, BookmarkDto>();
            CreateMap<BookmarkCreateRequest, BookmarkDto>().ForMember(e => e.Category, c => c.Ignore());
            CreateMap<BookmarkDto, BookmarkCreateRequest>().ForMember(e => e.Category, c => c.MapFrom(e => e.Category.Name));
        }
    }
}
