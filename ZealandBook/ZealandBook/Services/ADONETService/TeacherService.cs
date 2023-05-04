using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class TeacherService : ITeacherService
    {
        public void CreateTeacher(Teacher teacher)
        {
            SQLServiceTeacher.CreateTeacher(teacher);
        }
    }
}
