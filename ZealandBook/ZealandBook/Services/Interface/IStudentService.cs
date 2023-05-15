using ZealandBook.Models;

namespace ZealandBook.Services.Interface
{
    public interface IStudentService
    {
        public void CreateStudent(Student student);

        public List<Student> GetAllStudents();

        public Student GetStudentByEmailAndPassword(string email, string password);

        public List<Booking> GetBookingsForStudent(int studentId);
        void SetLoggedInStudent(Student student);
        Student GetLoggedInStudent();

        public Student GetStudentById(int studentId);

    }
}