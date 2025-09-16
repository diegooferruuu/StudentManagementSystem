using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services.Reports
{
    public interface IReportGenerator
    {  
        Report generateReport(Student student);
    }
}
