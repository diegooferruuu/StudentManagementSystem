using System.Globalization;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public class PdfReportGenerator : IReportGenerator
    {
        private readonly IScoreCalculator _calculator;

        public PdfReportGenerator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }

        public Report generateReport(Student student)
        {
            var report = new Report();

            // Crear documento
            var document = new Document();

            // Fuente global para todo el documento
            var normalStyle = document.Styles["Normal"];
            normalStyle.Font.Name = "LiberationSans";
            normalStyle.Font.Size = 12;

            // Contenido
            if (student == null)
            {
                var secEmpty = document.AddSection();
                secEmpty.AddParagraph("No student provided.");
            }
            else
            {
                BuildDocument(document, student);
            }

            // Renderizar a bytes
            var bytes = RenderDocumentToBytes(document);
            report.Body = bytes;
            report.MimeType = "application/pdf";

            return report;
        }

        private void BuildDocument(Document document, Student student)
        {
            var section = document.AddSection();

            // Header
            var header = section.AddParagraph($"Report for {student.firstName} {student.lastName}");
            header.Format.Font.Size = 14;
            header.Format.Font.Bold = true;

            section.AddParagraph($"ID: {student.StudentId}");
            section.AddParagraph();

            // Scores
            if (student.Scores == null || student.Scores.Count == 0)
            {
                section.AddParagraph("No scores available.");
            }
            else
            {
                var table = section.AddTable();
                table.Borders.Width = 0.75;
                table.AddColumn(Unit.FromCentimeter(6));
                table.AddColumn(Unit.FromCentimeter(4));
                table.AddColumn(Unit.FromCentimeter(2));

                var headerRow = table.AddRow();
                headerRow.Shading.Color = Colors.LightGray;
                headerRow.Cells[0].AddParagraph("Subject");
                headerRow.Cells[1].AddParagraph("Type");
                headerRow.Cells[2].AddParagraph("Score").Format.Alignment = ParagraphAlignment.Right;

                foreach (var s in student.Scores)
                {
                    var row = table.AddRow();
                    row.Cells[0].AddParagraph(s.Subject);
                    row.Cells[1].AddParagraph(s.Type);
                    row.Cells[2].AddParagraph(s.Value.ToString(CultureInfo.InvariantCulture));
                    row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                }

                section.AddParagraph();

                double avg = _calculator.CalculateAverage(student);
                var highest = _calculator.GetHighestScore(student);
                var lowestValue = student.Scores.Min(s => s.Value);
                var count = student.Scores.Count;

                var summary = section.AddParagraph("Summary");
                summary.Format.Font.Bold = true;

                section.AddParagraph($"Count: {count}");
                section.AddParagraph($"Average: {avg:0.00}");
                if (highest != null)
                    section.AddParagraph($"Highest: {highest.Subject} ({highest.Value})");
                section.AddParagraph($"Lowest: {lowestValue}");
            }
        }

        private byte[] RenderDocumentToBytes(Document document)
        {
            var renderer = new PdfDocumentRenderer()
            {
                Document = document
            };
            renderer.RenderDocument();

            using var ms = new MemoryStream();
            renderer.PdfDocument.Save(ms, false);
            return ms.ToArray();
        }
    }
}
