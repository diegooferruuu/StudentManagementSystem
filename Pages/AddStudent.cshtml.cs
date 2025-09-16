using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using StudentManagementSystem.Models;  
using StudentManagementSystem.Services;  
  
namespace StudentManagementSystem.Pages;  
  
public class AddStudent : PageModel  
{  
    private readonly StudentService _studentService;
    private readonly IStudentValidation _studentValidation;
  
    public AddStudent(StudentService studentService, IStudentValidation studentValidation)  
    {        
        _studentService = studentService;
        _studentValidation = studentValidation;
    }  
    [BindProperty]  
    public Student Student { get; set; } = new Student();  
  
    public void OnGet()  
    {    }  
    
    public IActionResult OnPost()  
    {        
        if (!ModelState.IsValid)  
        {
            return Page();  
        }

        var errors = _studentValidation.ValidateStudent(Student);
        if (errors.Any())
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return Page();
        }
        
        _studentService.AddStudent(Student);  
        return RedirectToPage("SeeStudents");  
    }
}