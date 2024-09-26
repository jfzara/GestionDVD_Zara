using Microsoft.EntityFrameworkCore;
using Zara_GestionDVD.Data;

var builder = WebApplication.CreateBuilder(args);

 
builder.WebHost.UseUrls("http://localhost:5002");  

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Utilisateurs}/{action=Login}/{id?}");  

app.Run();