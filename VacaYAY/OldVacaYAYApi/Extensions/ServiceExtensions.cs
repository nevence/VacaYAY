using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OldVacaYAYApi.Services;

namespace OldVacaYAYApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureOldVacaYAYService(this IServiceCollection services) =>
           services.AddScoped<IOldVacaYAYService, OldVacaYAYService>();
    }
}
