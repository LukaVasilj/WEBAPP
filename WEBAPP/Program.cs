using Microsoft.EntityFrameworkCore;
using WEBAPP.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Register

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "theaters",
    pattern: "{controller=Theaters}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "movies",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "showtimes",
    pattern: "{controller=Showtimes}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "genres",
    pattern: "{controller=Genres}/{action=Index}/{id?}");

app.Run();
