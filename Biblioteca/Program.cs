using Biblioteca;
using Biblioteca.bd;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var ConnectionStrings = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(ConnectionStrings));

builder.Services.AddScoped<IBiblioteca, SBiblioteca>();
builder.Services.AddScoped<ILibro, SLibro>();
builder.Services.AddScoped<IUsuario, SUsuario>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
