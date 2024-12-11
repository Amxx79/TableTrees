using Microsoft.AspNetCore.Mvc;
using Microsot.Extensions.DependencyInjection;
using TableTree.Data.Models;
using TableTree.Services.Data;

namespace TableTree.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDatabase(builder.Configuration);

            string adminUserEmail = builder.Configuration.GetValue<string>("AdminCredentials:Email")!;
            string adminUserPassword = builder.Configuration.GetValue<string>("AdminCredentials:Password")!;

            builder.Services.AddApplicationIdentity(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddMvc();

            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.SeedGlobalAdministrator(adminUserEmail, adminUserPassword);

            app.UseHttpsRedirection();

            app.UseStatusCodePages();

            app.UseStatusCodePagesWithRedirects("/StatusCodeError/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "routeForId",
                pattern: "{controller=Product}/{action=Delete}/{id?}");

            app.MapControllerRoute(
                name: "routeForAreas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
