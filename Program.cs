using Microsoft.EntityFrameworkCore;
using StudentManagement.Services;
using StudentManagementSystem.Context;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency injectables
builder.Services.AddScoped<IStudentRepository, DatabaseStudentRepository>();
builder.Services.AddScoped<IScoreCalculator, SimpleScoreCalculator>();
builder.Services.AddScoped<StudentService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
