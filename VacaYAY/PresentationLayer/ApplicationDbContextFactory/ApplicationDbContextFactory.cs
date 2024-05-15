using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Data;

namespace PresentationLayer.ApplicationDbContextFactory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
             b => b.MigrationsAssembly("PresentationLayer"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
