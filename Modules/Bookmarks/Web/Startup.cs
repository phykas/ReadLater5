using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadLater.Bookmarks.EntityFramework;
using ReadLater.Bookmarks.Init;
using ReadLater.Bookmarks.Web.Infrastructure;
using ReadLater.Utilities;
using Westwind.AspNetCore.LiveReload;

//todos
//dodaj current user, bookmarks and categories per user
//dodaj api token, kao field u bazi koji se random generise (guid) za svakog usera po potrebi
//dodaj api pristup pomocu tokena
//dodaj tracking modul
//dodaj cqrs
namespace ReadLater5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLiveReload();
            services.AddDatabaseDeveloperPageExceptionFilter();

            //FZ: Would add a todo to move to Authentication module and assign a new database
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                           .AddEntityFrameworkStores<ReadLaterDataContext>();

            services.AddUtilitiesModule();
            services.AddInfrastructureModule();
            services.AddBookmarksModule(new BookmarksConfiguration(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddAuthentication()
                           .AddGoogle(options =>
                           {
                               options.ClientId = "google-client-id";
                               options.ClientSecret = "google-client-secret";
                           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseLiveReload();
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
                endpoints.MapRazorPages().RequireAuthorization();
            });
        }
    }
}
