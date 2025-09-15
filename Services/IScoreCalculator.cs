using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IScoreCalculator
    {
        double CalculateAverage(Student student);
        Score GetHighestScore(Student student);
    }
}
