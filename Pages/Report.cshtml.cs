using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.Services.Reports;

namespace StudentManagementSystem.Pages;

public class Report : PageModel
{
    private readonly IStudentRepository _repo;
    private readonly ReportGeneratorCreator _reportGeneratorCreator;

    public string? ReportHtml { get; private set; }
    public Student? Student { get; private set; }

    public Report(IStudentRepository repo, HtmlReportGeneratorCreator reportGeneratorCreator)
    {
        _repo = repo;
        _reportGeneratorCreator = reportGeneratorCreator;
    }

    public void OnGet(int id)
    {
        Student = _repo.GetStudent(id);
        if (Student != null)
        {
            ReportHtml = _reportGeneratorCreator.generateReport(Student);
        }
    }
}