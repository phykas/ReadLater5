using Microsoft.Extensions.DependencyInjection;
using Readlater.Bookmarks.Automapper;
using ReadLater.Automapper;
using ReadLater.Bookmarks.Application;
using ReadLater.Bookmarks.EntityFramework;
using ReadLater.Mapper;

namespace ReadLater.Bookmarks.Init
{
    public static class BookmarksModule
    {
        public static IServiceCollection AddBookmarksModule(this IServiceCollection services, BookmarksConfiguration configuration)
        {
            services.AddBookmarksEntityFrameworkModule(configuration);

            services.AddScoped<IBookmarksMapperService>(provider => new BookmarksMapper(new AutomapperService(new[] {
                new BookmarksProfile()
            })));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
