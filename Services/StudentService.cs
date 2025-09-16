using StudentManagementSystem.Services;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services;

public class StudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IScoreCalculator _calculator;

    public StudentService(IStudentRepository studentRepository, IScoreCalculator calculator)
    {
        _studentRepository = studentRepository;
        _calculator = calculator;
    }
    public Student? GetStudent(int id)
    {
        return _studentRepository.GetStudent(id);
    }
    
    public void AddStudent(Student student)
    {
        _studentRepository.AddStudent(student);
    }

    public List<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }
}