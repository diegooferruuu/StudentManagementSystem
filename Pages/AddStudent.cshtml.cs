using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Pages;

public class AddStudent: PageModel
{
    private readonly StudentService _studentService;

    public AddStudent(StudentService studentService)
    {
        _studentService = studentService;
    }
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        String lastName = Request.Form["lastName"];
        String firstName = Request.Form["firstName"];

        Student student = new Student();
        student.FirstName = firstName;
        student.LastName = lastName;
        _studentService.AddStudent(student);

    }
}