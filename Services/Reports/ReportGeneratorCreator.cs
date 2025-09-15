using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public abstract class ReportGeneratorCreator
    {
        public abstract IReportGenerator createReportGenerator();
        public  IReportGenerator generateReport(Student student)
        {
            IReportGenerator reportGenerator = createReportGenerator();
            return reportGenerator.generateReport(student);

        }

    }
}
