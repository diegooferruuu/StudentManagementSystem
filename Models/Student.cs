using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Score> Scores { get; set; } = new();
}