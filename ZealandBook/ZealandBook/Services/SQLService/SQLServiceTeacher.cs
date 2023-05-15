using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceTeacher
    {
        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ZealandBook;Integrated Security=True";
        public static void CreateTeacher(Teacher teacher)
        {
            string query = $"INSERT into Teacher(Name, Email, Admin) Values(@Name, @Email, @Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", teacher.TeacherName);
                    command.Parameters.AddWithValue("@Email", teacher.TeacherEmail);
                    command.Parameters.AddWithValue("@Admin", teacher.Password);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
