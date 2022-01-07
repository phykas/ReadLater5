using Microsoft.Extensions.DependencyInjection;
using ReadLater.Automapper;
using ReadLater.Bookmarks.Application;
using ReadLater.Bookmarks.Application.Bookmarks;
using ReadLater.Bookmarks.Application.Mappers;
using ReadLater.Bookmarks.Automapper;
using ReadLater.Bookmarks.EntityFramework;

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
            services.AddScoped<IBookmarksService, BookmarksService>();
            services.AddScoped<IBookmarksRepository, BookmarksRepository>();
            return services;
        }
    }
}
