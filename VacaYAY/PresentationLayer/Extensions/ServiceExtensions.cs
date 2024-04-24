using DataAccesLayer.Data;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace PresentationLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration) =>
           services.AddIdentity<Employee, IdentityRole<int>>(opt =>
           {
               opt.Password.RequiredLength = 8;
               opt.User.RequireUniqueEmail = true;
               opt.Password.RequireNonAlphanumeric = false;
               opt.SignIn.RequireConfirmedEmail = true;
           })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

    }
}
