using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Pages;

public class SeeStudents : PageModel
{
    private readonly StudentService _studentService;

    public SeeStudents(StudentService studentService)
    {
        _studentService = studentService;
    }
    public List<Student> Students { get; set; } = new();

    public void OnGet()
    {
        Students = _studentService.GetAllStudents();
    }
    
    public void OnPost()
    {
        
    }
}