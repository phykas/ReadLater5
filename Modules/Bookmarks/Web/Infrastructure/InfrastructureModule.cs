using Microsoft.Extensions.DependencyInjection;
using ReadLater.Bookmarks.Authentication;

namespace ReadLater.Bookmarks.Web.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}
