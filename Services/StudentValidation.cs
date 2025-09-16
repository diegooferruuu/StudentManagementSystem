using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services;

public class StudentValidation: IStudentValidation
{
    private readonly StudentService _studentService;

    public StudentValidation(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    public List<string> ValidateStudent(Student student)
    {
        var errors = new List<string>();
        errors.AddRange(ValidateAge(student.DateOfBirth));
        errors.AddRange(ValidateId(student.StudentId));
        errors.AddRange(ValidatePhoneNumber(student.Phone));
        errors.AddRange(ValidateEmail(student.Email));
        // Add more field validations here
        return errors;
    }

    private List<string> ValidateAge(DateTime dob)
    {
        var errors = new List<string>();
        var age = DateTime.Today.Year - dob.Year;
        if (dob > DateTime.Today.AddYears(-age)) age--;
        if (age < 12)
            errors.Add("Student must be at least 12 years old.");
        return errors;
    }

    private List<string> ValidateId(string studentId)
    {
        var errors = new List<string>();
        var existing = _studentService
            .GetAllStudents()
            .Any(s => s.StudentId == studentId);

        if (existing)
            errors.Add("A student with this name already exists.");
        return errors;
    }
    
    private List<string> ValidatePhoneNumber(string phoneNumber)
    {
        var errors = new List<string>();
        var existing = _studentService
            .GetAllStudents()
            .Any(s => s.Phone == phoneNumber);

        if (existing)
            errors.Add("A student with this phone number already exists.");
        return errors;
    }
    
    private List<string> ValidateEmail(string email)
    {
        var errors = new List<string>();
        var existing = _studentService
            .GetAllStudents()
            .Any(s => s.Email == email);

        if (existing)
            errors.Add("A student with this email already exists.");
        return errors;
    }
    
}