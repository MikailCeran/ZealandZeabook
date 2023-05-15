using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class StudentService : IStudentService
    {
        public void CreateStudent(Student student)
        {
            SQLServiceStudent.CreateStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return SQLServiceStudent.GetAllStudents();
        }

        public Student GetStudentByEmailAndPassword(string email, string password)
        {
            return SQLServiceStudent.GetStudentByEmailAndPassword(email, password);
        }

        //public List<Booking> GetBookingsForStudent(int studentId)
        //{
        //    return SQLServiceStudent.GetBookingsForStudent(studentId);
        //}
    }
}
