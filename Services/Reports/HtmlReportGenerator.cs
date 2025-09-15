using System.Globalization;
using System.Text;
using StudentManagementSystem.Services;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports;

public class HtmlReportGenerator : IReportGenerator
{
    private readonly IScoreCalculator _calculator;

    public HtmlReportGenerator(IScoreCalculator calculator)
    {
        _calculator = calculator;
    }

    public string generateReport(Student student)
    {
        if (student == null) return "<p>No student provided.</p>";

        var sb = new StringBuilder();

        // Header
        sb.AppendLine($"<div class=\"student-report\">");
        sb.AppendLine($"  <h2>Report for {System.Net.WebUtility.HtmlEncode(student.firstName + student.lastName)}</h2>");
        sb.AppendLine($"  <p><strong>ID:</strong> {System.Net.WebUtility.HtmlEncode(student.StudentId.ToString())}</p>");

        // Scores table
        if (student.Scores == null || student.Scores.Count == 0)
        {
            sb.AppendLine("<p>No scores available.</p>");
        }
        else
        {
            sb.AppendLine("<table class=\"table table-sm\" style=\"border-collapse:collapse; width:100%;\">");
            sb.AppendLine("  <thead>");
            sb.AppendLine("    <tr>");
            sb.AppendLine("      <th style=\"border:1px solid #ddd; padding:8px; text-align:left;\">Subject</th>");
            sb.AppendLine("      <th style=\"border:1px solid #ddd; padding:8px; text-align:left;\">Type</th>");
            sb.AppendLine("      <th style=\"border:1px solid #ddd; padding:8px; text-align:right;\">Score</th>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("  </thead>");
            sb.AppendLine("  <tbody>");

            foreach (var s in student.Scores)
            {
                sb.AppendLine("    <tr>");
                sb.AppendLine($"      <td style=\"border:1px solid #ddd; padding:8px;\">{System.Net.WebUtility.HtmlEncode(s.Subject)}</td>");
                sb.AppendLine($"      <td style=\"border:1px solid #ddd; padding:8px;\">{System.Net.WebUtility.HtmlEncode(s.Type)}</td>");
                sb.AppendLine($"      <td style=\"border:1px solid #ddd; padding:8px; text-align:right;\">{s.Value}</td>");
                sb.AppendLine("    </tr>");
            }

            sb.AppendLine("  </tbody>");
            sb.AppendLine("</table>");

            // Calculated stats using the calculator
            double avg = _calculator.CalculateAverage(student);
            var highest = _calculator.GetHighestScore(student);
            var lowestValue = student.Scores.Min(s => s.Value);
            var count = student.Scores.Count;

            sb.AppendLine("<div class=\"report-summary\" style=\"margin-top:10px;\">");
            sb.AppendLine($"  <p><strong>Count:</strong> {count}</p>");
            sb.AppendLine($"  <p><strong>Average:</strong> {avg.ToString("0.00", CultureInfo.InvariantCulture)}</p>");
            if (highest != null)
                sb.AppendLine($"  <p><strong>Highest:</strong> {System.Net.WebUtility.HtmlEncode(highest.Subject)} ({highest.Value})</p>");
            sb.AppendLine($"  <p><strong>Lowest:</strong> {lowestValue}</p>");
            sb.AppendLine("</div>");
        }

        sb.AppendLine("</div>"); // container
        return sb.ToString();
    }
}