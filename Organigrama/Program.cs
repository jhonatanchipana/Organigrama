using Microsoft.EntityFrameworkCore;
using Organigrama;
using Organigrama.Repositories;
using Organigrama.Repositories.Interfaces;
using Organigrama.Repositorys;
using Organigrama.Repositorys.Interfaces;
using Organigrama.Services;
using Organigrama.Services.Interfaces;
using Organigrama.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IWorkStationRepository, WorkStationRepository>();
builder.Services.AddTransient<IWorkStationService, WorkStationService>();
builder.Services.AddTransient<ILevelService, LevelService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(opciones =>
{
    opciones.UseSqlServer("name=DefaultConnection");
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
    pattern: "{controller=OrganizationChart}/{action=Index}/{id?}");

app.Run();
