using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using StudentManagementSystem.Models;
using System.Linq;
using System.Reflection.Metadata;


namespace StudentManagementSystem.Services.Reports
{
    public class PdfReportGenerator : IReportGenerator
    {
        private readonly IScoreCalculator _calculator;

        public PdfReportGenerator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }

        public string generateReport(Student student)
        {
            if (student == null) return "No student provided.";

            var fileName = $"{student.firstName}_{student.lastName}_Report.pdf";

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(QuestPDF.Helpers.PageSizes.A4);

                    page.Header()
                        .Text($"Report for {student.firstName} {student.lastName}")
                        .SemiBold().FontSize(20).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                    page.Content()
                        .Column(col =>
                        {
                            col.Item().Text($"ID: {student.StudentId}");

                            if (student.Scores == null || student.Scores.Count == 0)
                            {
                                col.Item().Text("No scores available.");
                            }
                            else
                            {
                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Subject");
                                        header.Cell().Text("Type");
                                        header.Cell().Text("Score");
                                    });

                                    foreach (var s in student.Scores)
                                    {
                                        table.Cell().Text(s.Subject);
                                        table.Cell().Text(s.Type);
                                        table.Cell().Text(s.Value.ToString());
                                    }
                                });

                                double avg = _calculator.CalculateAverage(student);
                                var highest = _calculator.GetHighestScore(student);
                                var lowestValue = student.Scores.Min(s => s.Value);
                                var count = student.Scores.Count;

                                col.Item().Text($"Count: {count}");
                                col.Item().Text($"Average: {avg:0.00}");
                                if (highest != null)
                                    col.Item().Text($"Highest: {highest.Subject} ({highest.Value})");
                                col.Item().Text($"Lowest: {lowestValue}");
                            }
                        });
                });
            })
            .GeneratePdf(fileName);

            return $"PDF report generated: {fileName}";
        }
    }
}
