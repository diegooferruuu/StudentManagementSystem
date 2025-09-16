using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public class HtmlReportGeneratorCreator : ReportGeneratorCreator
    {
        private readonly IScoreCalculator _calculator;

        public HtmlReportGeneratorCreator(IScoreCalculator calculator)
        {
            _calculator = calculator;
        }

        public override IReportGenerator createReportGenerator()
        {
            return new HtmlReportGenerator(_calculator);
        }
    }
}
