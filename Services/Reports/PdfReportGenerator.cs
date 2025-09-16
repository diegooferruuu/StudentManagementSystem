using MigraDoc.Rendering;
using StudentManagementSystem.Models;
using System.Reflection.Metadata;
using MigraDoc.DocumentObjectModel;
using Document = MigraDoc.DocumentObjectModel.Document;


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
            var document = new Document();

            BuildDocument(document);

            var pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;

            Report report = new Report();
            report.Body = pdfRenderer.PdfDocument;
            report.MimeType = "pdf";
            
            return report;
        }

        private void BuildDocument(Document document)
        {
            Section section = document.AddSection();
        }
    }
}
