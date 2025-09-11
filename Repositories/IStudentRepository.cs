using StudentManagementSystem.Pages;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        public void AddStudent(Student student);
        public Student getStudent(string id);
        public List<Student> getAllStudents();

    }
}
