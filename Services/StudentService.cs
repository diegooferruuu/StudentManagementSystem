using StudentManagement.Services;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services;

public class StudentService
{
    private readonly IStudentRepository _repository;
    private readonly IScoreCalculator _calculator;

    public StudentService(IStudentRepository repository, IScoreCalculator calculator)
    {
        _repository = repository;
        _calculator = calculator;
    }
    public Student GetStudent(int id)
    {
        return _repository.GetStudent(id);
    }
    
    public void AddStudent(Student student)
    {
        _repository.AddStudent(student);
    }

    public List<Student> GetAllStudents()
    {
        return _repository.GetAllStudents();
    }
    
    public double CalculateAverageScore(int id)
    {
        Student student = GetStudent(id);
        return _calculator.CalculateAverage(student);
    }
}