using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public interface IReportGenerator
    {
        IReportGenerator generateReport(Student student);
    }
}
