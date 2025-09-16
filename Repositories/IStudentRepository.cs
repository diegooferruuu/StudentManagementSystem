using StudentManagementSystem.Pages;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        public void AddStudent(Student student);
        public Student? GetStudent(String id);
        public List<Student> GetAllStudents();

    }
}
