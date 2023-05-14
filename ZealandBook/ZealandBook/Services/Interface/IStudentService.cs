using ZealandBook.Models;

namespace ZealandBook.Services.Interface
{
    public interface IStudentService
    {
        public void CreateStudent(Student student);

        public List<Student> GetAllStudents();

        public Student GetStudentByEmailAndPassword(string username, string password);


    }
}