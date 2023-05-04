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
    }
}
