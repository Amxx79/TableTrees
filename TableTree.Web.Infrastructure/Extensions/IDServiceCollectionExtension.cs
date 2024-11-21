using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Principal;
using TableTree.Data;
using TableTree.Data.Models;
using TableTree.Data.Repository;
using TableTree.Data.Repository.Interfaces;
using TableTree.Services.Data;
using TableTree.Services.Data.Interfaces;

namespace Microsot.Extensions.DependencyInjection
{
    public static class IDServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoles<ApplicationRole>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<ShoppingCart>, Repository<ShoppingCart>>();
            services.AddScoped<IRepository<FavouriteProduct>, Repository<FavouriteProduct>>();
            services.AddScoped<IRepository<ProductStore>, Repository<ProductStore>>();
            services.AddScoped<IRepository<Store>, Repository<Store>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IAvailabilityService, AvailabilityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IAccountService, AccountService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
