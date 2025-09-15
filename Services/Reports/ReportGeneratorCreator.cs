using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public abstract class ReportGeneratorCreator
    {
        public abstract IReportGenerator createReportGenerator();
        public  string generateReport(Student student)
        {
            var reportGenerator = createReportGenerator();
            return reportGenerator.generateReport(student);

        }

    }
}
