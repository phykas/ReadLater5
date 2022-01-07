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
            CreateMap<BookmarkRequest, BookmarkDto>().ForMember(e => e.Category, c => c.Ignore());
            CreateMap<BookmarkDto, BookmarkRequest>().ForMember(e => e.Category, c => c.MapFrom(e => e.Category.Name));
        }
    }
}
