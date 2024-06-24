using DataAccesLayer.Configuration;
using DataAccesLayer.Data;
using DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.ActionFilters;
using PresentationLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ErrorExceptionFilter>();
});
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.AddScoped<DataSeeder>();
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection(ApiConfig.ApiConfiguration));
builder.Services.AddHttpClient();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dataSeeder = services.GetRequiredService<DataSeeder>();

        await dataSeeder.SeedEmployeesAndPositionsAsync();

        dataSeeder.SeedVacationRequests();
    }
    catch (Exception ex)
    { 
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}"
        );
    });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Employee}/{action=Index}/{id?}"
    );
});


app.Run();
