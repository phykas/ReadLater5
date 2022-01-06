using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadLater.Bookmarks.EntityFramework;

namespace ReadLater.Bookmarks.Init
{
    public static class BookmarksEntityFrameworkModule
    {
        public static IServiceCollection AddBookmarksEntityFrameworkModule(this IServiceCollection services, BookmarksConfiguration configuration)
        {
            services.AddDbContext<ReadLaterDataContext>(options => options.UseSqlServer(configuration.ConnectionString));
            return services;
        }
    }
}
