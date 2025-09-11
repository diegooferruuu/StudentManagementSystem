namespace StudentManagementSystem.Models;

public class Score
{
    public int ScoreId { get; set; }
    public string Subject { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Type { get; set; } = string.Empty;

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}