using eshop.MVC.ExtensionMerhods;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddMvcOptions(option =>
                {
                    option.Filters.Add(new ResponseCacheAttribute { Duration = 300, Location = ResponseCacheLocation.Client });
                });


var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddIoCForThisProject(connectionString);

builder.Services.AddSession();

//builder.Services.AddCookiePolicy()




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Kullanici/Giris";
                    option.ReturnUrlParameter = "nerelereGidem";
                    option.AccessDeniedPath = "/Kullanici/Yasak";
                });


builder.Services.AddResponseCaching();
var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseSession();
app.UseRouting();

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();




app.MapControllerRoute(name: "categoryFilter",
                       pattern: "Kategori/{categoryId?}",
                       defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
