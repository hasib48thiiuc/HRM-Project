using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Tabulator_Crud.Models;
using Tabulator_Crud.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<TabulatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<ICompanyRepository,CompanyRepository>();
builder.Services.AddTransient<IDesignationRepository,DesignationRepository>();
builder.Services.AddTransient<IShiftRepository,ShiftRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IAttendanceRepository ,AttendanceRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.Cookie.Name = "YourCookieName";
    options.LoginPath = "/Account/Login"; // Change this to the login path in your application
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
    pattern: "{controller=Company}/{action=Show}/{id?}");

app.Run();
