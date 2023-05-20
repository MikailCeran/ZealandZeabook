namespace ZealandBook.Models
{
    public class Teacher
    {
        public  int TeacherID{ get; set; }
        public  string TeacherName{ get; set; }
        public  string TeacherEmail{ get; set; }
        public  bool Admin{ get; set; }
        public string Password { get; set; }
    }
}
