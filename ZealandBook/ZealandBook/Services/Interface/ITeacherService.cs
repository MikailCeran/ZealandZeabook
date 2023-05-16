using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.Interface
{
    public interface ITeacherService
    {
        public void CreateTeacher(Teacher teacher);

        public Teacher GetTeacherById(int id);
        public Teacher GetTeacherByEmailAndPassword(string email, string password);
        public List<Booking> GetBookingsForTeacher(int id);
        public void SetLoggedInTeacher(Teacher teacher);
        public Teacher GetLoggedInTeacher();
    }
}




