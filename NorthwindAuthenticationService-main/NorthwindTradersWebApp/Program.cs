using NorthwindModelClassLibrary;
using NorthwindTradersWebApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<ApiConfigurations>(builder.Configuration.GetSection("ApiConfigurations"))
    .AddHttpContextAccessor()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IRepositoryAsync<Product>, ProductsApiRepository>()
    .AddSession(config=>
    {
        config.IdleTimeout = TimeSpan.FromMinutes(30);
        config.Cookie.Name = "ASPNET_Session";
        config.Cookie.HttpOnly = true;
        
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
