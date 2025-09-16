using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Pages;

public class AddStudent : PageModel
{
    private readonly StudentService _studentService;

    public AddStudent(StudentService studentService)
    {
        _studentService = studentService;
    }

    [BindProperty]
    public Student Student { get; set; } = new Student();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _studentService.AddStudent(Student);
        return RedirectToPage("SeeStudents");
    }
}