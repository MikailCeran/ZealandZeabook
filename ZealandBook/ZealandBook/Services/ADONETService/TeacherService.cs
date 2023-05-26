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
        public Teacher GetTeacherByEmailAndPassword(string email, string password)
        {
            return SQLServiceTeacher.GetTeacherByEmailAndPassword(email, password);
        }

     
        public List<Booking> GetBookingsForTeacher(int Id)
        {
            return SQLServiceTeacher.GetBookingsForTeacher(Id);
            
        }
        public Teacher GetTeacherById(int id)
        {
            return SQLServiceTeacher.GetTeacherById(id);
        }

        private Teacher _loggedInTeacher;

        public void SetLoggedInTeacher(Teacher teacher)
        {
            _loggedInTeacher = teacher;
        }

        public Teacher GetLoggedInTeacher()
        {
            return _loggedInTeacher;
        }
    }
}
