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

    public Student? getStudent(string id)
    {
        if (!int.TryParse(id, out var studentId))
            return null;

        return _context.Students
            .Include(s => s.Scores)
            .FirstOrDefault(s => s.StudentId == studentId);
    }

    public List<Student> getAllStudents()
    {
        return _context.Students
            .Include(s => s.Scores)
            .ToList();
    }
}