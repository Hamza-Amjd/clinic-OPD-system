using DAL;
using DAL.Models;
using DAL.Interface;
using BLL;
using Microsoft.EntityFrameworkCore;
using BLL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MedeaseDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

builder.Services.AddScoped<IPatientsDA, PatientsDA>();
builder.Services.AddScoped<IPatientBC, PatientBC>();

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

app.Run();
