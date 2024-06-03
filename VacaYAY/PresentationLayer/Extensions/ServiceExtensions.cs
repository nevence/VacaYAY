using DataAccesLayer.Data;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using DataAccesLayer.Contracts;
using DataAccesLayer.Repositories;
using DataAccesLayer.Interceptors;
using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace PresentationLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        { 
            services.AddTransient<SoftDeleteInterceptor>();
            services.AddDbContext<ApplicationDbContext>((sp, opts) =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));
        }

        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Employee, IdentityRole<int>>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
         .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
             services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
           services.AddScoped<IServiceManager, ServiceManager>();

    }
}
