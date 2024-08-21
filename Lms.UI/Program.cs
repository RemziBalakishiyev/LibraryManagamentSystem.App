using FluentValidation;
using Lms.BusinessLogic;
using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Concrete;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.ValidationRules;
using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Concrete;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Books;
using Lms.ExternalServices.Classes;
using Lms.ExternalServices.Interfaces;
using Lms.ExternalServices.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("local")!;
builder.Services
    .AddDbContext<LmsContext>(options => options.UseSqlServer(connectionString));

var emailConfigurations = builder.Configuration.GetSection("SmtpSetting")!;
builder.Services.Configure<SmtpSetting>(emailConfigurations);

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddAutoMapper(typeof(IRegisterDependency));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddScoped<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IValidator<CreateUserDto>,CreateUserValidator>();
builder.Services.AddScoped<IValidator<SigninUserDto>,SigninUserDtoValidator>();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/authentication/signin"; 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/auth/authentication/signin"; 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseHttpsRedirection(); 
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Area routing should come first
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Book}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Authentication}/{action=Register}/{id?}"
);

// Default route for non-area controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();