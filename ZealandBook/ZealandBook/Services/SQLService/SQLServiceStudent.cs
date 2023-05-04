using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceStudent
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void CreateStudent(Student student)
        {
            string query = $"INSERT into Student(Name, Email) Values(@Name, @Email)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}