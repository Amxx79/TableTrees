using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            services.AddScoped<IRepository<OrderItemInfo>, Repository<OrderItemInfo>>();
            services.AddScoped<IAvailabilityService, AvailabilityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IAccountService, AccountService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static async Task<IApplicationBuilder> SeedGlobalAdministrator(this IApplicationBuilder app, string email, string password)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
            RoleManager<ApplicationRole>? roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            UserManager<ApplicationUser>? userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            IUserStore<ApplicationUser>? userStore = serviceProvider.GetService<IUserStore<ApplicationUser>>();
            SignInManager<ApplicationUser>? signInManager = serviceProvider.GetService<SignInManager<ApplicationUser>>();
            
            ApplicationUser applicationUser = await userManager.FindByEmailAsync(email);

            if (applicationUser != null)
            {
                return app;
            }

            if (roleManager == null)
            {
                throw new ArgumentNullException("Service cannot be obtained");
            }

            ApplicationUser applicationAdmin = new ApplicationUser() 
            {
                Email = email,
                UserName = email,
            };

            IdentityResult result =  await userManager.CreateAsync(applicationAdmin, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Error occurred while registering user!");
            }

            var claimsPrincipalUser = await signInManager.CreateUserPrincipalAsync(applicationAdmin);

            string roleGlobalAdmin = "GlobalAdmin";
            string roleAdmin = "Admin";

            if (await roleManager.RoleExistsAsync(roleGlobalAdmin) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(roleGlobalAdmin));
            }
            if (await roleManager.RoleExistsAsync(roleAdmin) == false)
            {
                result = await roleManager.CreateAsync(new ApplicationRole(roleAdmin));
            }

            if (claimsPrincipalUser.IsInRole(roleGlobalAdmin) == false && (result == null || result.Succeeded))
            {
                var currentUser = await userManager.FindByNameAsync(claimsPrincipalUser.Identity.Name);

                if (claimsPrincipalUser != null)
                {
                    await userManager.AddToRoleAsync(currentUser, roleGlobalAdmin);
                }
            }

            if (claimsPrincipalUser.IsInRole(roleAdmin) == false && (result == null || result.Succeeded))
            {
                var currentUser = await userManager.FindByNameAsync(claimsPrincipalUser.Identity.Name);

                if (claimsPrincipalUser != null)
                {
                    await userManager.AddToRoleAsync(currentUser, roleAdmin);
                }
            }
                return app;
        }
    }
}
