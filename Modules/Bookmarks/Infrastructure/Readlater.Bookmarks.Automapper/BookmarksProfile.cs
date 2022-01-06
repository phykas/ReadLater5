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
        }
    }
}
