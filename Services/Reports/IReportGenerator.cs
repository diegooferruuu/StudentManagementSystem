using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public interface IReportGenerator
    {
        string generateReport(Student student);
    }
}
