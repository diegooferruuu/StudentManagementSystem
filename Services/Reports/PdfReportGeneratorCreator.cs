using StudentManagementSystem.Services;
using StudentManagementSystem.Services.Reports;

namespace StudentManagementSystem.Services.Reports
{
    public class PdfReportGeneratorCreator : ReportGeneratorCreator
    {
        private readonly IScoreCalculator _calculator;
        public PdfReportGeneratorCreator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }
        public override IReportGenerator createReportGenerator()
        {
            return new PdfReportGenerator(_calculator);
        }

    }
}


