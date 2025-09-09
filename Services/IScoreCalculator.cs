using StudentManagementSystem.Models;

namespace StudentManagement.Services
{
    public interface IScoreCalculator
    {
        double CalculateAverage(Student student);
        Score GetHighestScore(Student student);
    }
}
