using Microsoft.EntityFrameworkCore;
using VaccineManagement.Data;
using VaccineManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// EF Core + SQL Server
builder.Services.AddDbContext<VaccineContext>(opts =>
    opts.UseSqlServer("Server=CS3;" +
  "Database=cs4540stu18;" +
  "User Id=cs4540stu18;" +
  "Password=9XvfcPDve6Sq;" +
  "Encrypt=False;TrustServerCertificate=True;"));

// MVC services
builder.Services.AddControllersWithViews();

// make VaccineRepository available for injection
builder.Services.AddScoped<VaccineRepository>();

var app = builder.Build();

// middleware & routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();