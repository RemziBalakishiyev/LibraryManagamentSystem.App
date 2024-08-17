using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Concrete;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("local")!;
builder.Services
    .AddDbContext<LmsContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area}/{controller=Book}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();