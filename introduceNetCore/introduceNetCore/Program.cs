var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var app = builder.Build();

/*
 * Soda dolum tesisi.
 * 1. Şişeye etiket bas. --> Middleware 
 * 2. Sodayı doldur 
 * 3. Kapağı kapat 
 * 4. Kasaya yerleştir. 
 * 
 * Akış pipeline... 
 * Her bir iş middleware....
 */

//app.UseWelcomePage();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
