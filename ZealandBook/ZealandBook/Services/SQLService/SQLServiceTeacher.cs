using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceTeacher
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void CreateTeacher(Teacher teacher)
        {
            string query = $"INSERT into Teacher(TeacherName, TeacherEmail, Admin) Values(@TeacherName, @TeacherEmail, @Admin)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherName", teacher.TeacherName);
                    command.Parameters.AddWithValue("@TeacherEmail", teacher.TeacherEmail);
                    command.Parameters.AddWithValue("@Admin", teacher.Admin);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
