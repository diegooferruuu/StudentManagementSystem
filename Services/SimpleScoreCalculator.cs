using StudentManagement.Services;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class SimpleScoreCalculator : IScoreCalculator
    {
        public double CalculateAverage(Student student)
        {
            var scores = student.Scores;
            if (scores == null || !scores.Any())
                return 0.0;

            return scores.Average(s => s.Value);
        }

        public Score GetHighestScore(Student student)
        {
            var scores = student.Scores;
            if (scores == null || !scores.Any())
                return null;

            return scores.OrderByDescending(s => s.Value).First();
        }
    }
}
