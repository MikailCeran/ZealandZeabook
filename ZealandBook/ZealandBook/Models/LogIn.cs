namespace ZealandBook.Models
{
    public class LogIn
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //FK
        public int Student_Id {get; set;}
        public int Teacher_Id { get; set; }

    }
}
