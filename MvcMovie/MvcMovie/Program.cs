using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

//=====================================================================================
// Get started with ASP.NET Core MVC
// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc
//=====================================================================================
namespace MvcMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //=====================================================================================
            // Patch in the connection sting that is in the appsettings.json file
            //=====================================================================================

            builder.Services.AddDbContext<MvcMovieContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //=====================================================================================
            // Add any dependency injections stuff here before the builder BUILD() is called!!!
            //=====================================================================================

            //=====================================================================================
            // Call Builder.BUILD() -
            // See: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder
            // See: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplication
            //=====================================================================================
            var app = builder.Build();

            //=====================================================================================
            // Seed the database
            //=====================================================================================
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            //=====================================================================================
            // For production environments that are implementing HTTPS for the first time, set the
            // initial HstsOptions.MaxAge to a small value using one of the TimeSpan methods. Set
            // the value from hours to no more than a single day in case you need to revert the
            // HTTPS infrastructure to HTTP. After you're confident in the sustainability of the
            // HTTPS configuration, increase the HSTS max-age value; a commonly used value is one year.
            //=====================================================================================
            //The following highlighted code:
            //=====================================================================================
            //builder.Services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //    options.ExcludedHosts.Add("example.com");
            //    options.ExcludedHosts.Add("www.example.com");
            //});

            //=====================================================================================
            // Configure the HTTP request pipeline. ASP.NET Core implements HSTS with the UseHsts
            // extension method. The following code calls UseHsts when the app isn't in development mode.
            //=====================================================================================
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //=====================================================================================
            // When authorizing a resource that is routed using endpoint routing, this call must
            // appear between the calls to app.UseRouting() and app.UseEndpoints(...) for the
            // middleware to function correctly.
            app.UseAuthorization();
            //=====================================================================================

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}