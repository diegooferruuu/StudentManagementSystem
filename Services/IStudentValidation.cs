using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services;

public interface IStudentValidation
{
    List<String> ValidateStudent(Student student);
}