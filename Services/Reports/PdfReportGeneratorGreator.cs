using StudentManagementSystem.Services;
using StudentManagementSystem.Services.Reports;

namespace StudentManagementSystem.Services.Reports
{
    public class PdfReportGeneratorGreator : ReportGeneratorCreator
    {
        private readonly IScoreCalculator _calculator;
        public PdfReportGeneratorGreator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }
        public override IReportGenerator createReportGenerator()
        {
            return new PdfReportGenerator(_calculator);
        }

    }
}


