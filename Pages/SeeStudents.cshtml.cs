using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using StudentManagementSystem.Services.Reports;

namespace StudentManagementSystem.Pages;

public class SeeStudents : PageModel
{
    private readonly StudentService _studentService;
    private readonly IReportGenerator _reportGenerator;

    public SeeStudents(StudentService studentService, IReportGenerator reportGenerator)
    {
        _studentService = studentService;
        _reportGenerator = reportGenerator;
    }
    public List<Student> Students { get; set; } = new();

    public void OnGet()
    {
        Students = _studentService.GetAllStudents();
    }

    public void OnPost()
    {

    }
    
    public IActionResult OnGetExportPdf(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();

            var report = _reportGenerator.generateReport(student);

            if (report.Body is byte[] pdfBytes)
            {
                return File(pdfBytes, report.MimeType, $"Report_{student.firstName}_{student.lastName}.pdf");
            }
            else
            {
                return BadRequest("Report body is not a valid PDF");
            }
        }
}