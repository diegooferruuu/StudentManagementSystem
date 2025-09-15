using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Context;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories;

public class DatabaseStudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public DatabaseStudentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public Student? GetStudent(int id)
    {
        return _context.Students
            .Include(s => s.Scores)
            .FirstOrDefault(s => s.StudentId == id);
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students
            .Include(s => s.Scores)
            .ToList();
    }
}