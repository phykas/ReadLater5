using Microsoft.Extensions.DependencyInjection;

namespace ReadLater.Utilities
{
    public static class UtilitiesModule
    {
        public static IServiceCollection AddUtilitiesModule(this IServiceCollection services)
        {
            services.AddScoped<IClock, UtcClock>();
            return services;
        }
    }
}
