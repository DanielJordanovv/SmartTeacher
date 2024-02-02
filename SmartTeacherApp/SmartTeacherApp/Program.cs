using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartTeacher.Data;
using SmartTeacher.Services.Data;
using SmartTeacher.Services.Data.Interfaces;
using SmartTeacherApp.Controllers;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SmartTeacherDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SmartTeacher.Data")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser> (options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

})
    .AddEntityFrameworkStores<SmartTeacherDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
