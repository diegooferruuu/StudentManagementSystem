using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models;

public class Student
{
    public int StudentId { get; set; }
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;

    public List<Score> Scores { get; set; } = new();
}