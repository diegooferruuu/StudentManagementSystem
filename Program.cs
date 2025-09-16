using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using StudentManagementSystem.Services;
using StudentManagementSystem.Context;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Services;
using StudentManagementSystem.Services.Reports;
using PdfSharp.Fonts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency injectables
builder.Services.AddScoped<IStudentRepository, DatabaseStudentRepository>();
builder.Services.AddScoped<IScoreCalculator, SimpleScoreCalculator>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<HtmlReportGeneratorCreator>();
builder.Services.AddScoped<IStudentValidation, StudentValidation>();
builder.Services.AddScoped<PdfReportGeneratorCreator>();
builder.Services.AddScoped<IReportGenerator, PdfReportGenerator>(sp =>
{
    var calculator = sp.GetRequiredService<IScoreCalculator>();
    return new PdfReportGenerator(calculator);
});

// Add services to the container.
builder.Services.AddRazorPages();
GlobalFontSettings.FontResolver = new CustomFontResolver();

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
