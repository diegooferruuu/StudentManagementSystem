using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using StudentManagementSystem.Services.Reports;

namespace StudentManagementSystem.Pages;

public class Report : PageModel
{
    private readonly StudentService _studentService;
    private readonly ReportGeneratorCreator _reportGeneratorCreator;

    public Object? ReportHtml { get; private set; }
    public Student? Student { get; private set; }

    public Report(StudentService studentService, HtmlReportGeneratorCreator reportGeneratorCreator)
    {
        _studentService = studentService;
        _reportGeneratorCreator = reportGeneratorCreator;
    }

    public void OnGet(int id)
    {
        Student = _studentService.GetStudent(id);
        if (Student != null)
        {
            ReportHtml = _reportGeneratorCreator.generateReport(Student).Body;
        }
    }
}