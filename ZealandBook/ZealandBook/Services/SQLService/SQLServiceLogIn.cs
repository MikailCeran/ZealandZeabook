using Microsoft.Data.SqlClient;
using ZealandBook.Models;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceLogIn
    {

        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<LogIn> GetAllUsers()
        {

            List<LogIn> rooms = new List<LogIn>();
            string query = "Select * from LogIn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogIn user = new LogIn();
                        user.User_Id = Convert.ToInt32(reader[0]);
                        user.Username = Convert.ToString(reader[1]);
                        user.Password = Convert.ToString(reader[2]);
                        user.Student_Id = Convert.ToInt32(reader[3]);
                        user.Teacher_Id = Convert.ToInt32(reader[4]); 
                        rooms.Add(user);

                    }
                }
            }
            return rooms;
        }


        public static void CreateUser(LogIn user)
        {
            string query = $"INSERT into LogIn(User_Id,Username,Password, Student_Id,Teacher_Id) Values(@User_Id,@Username,@Password, @Student_Id,@Teacher_Id)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_Id", user.User_Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Student_Id", user.Student_Id);
                    command.Parameters.AddWithValue("@Teacher_Id", user.Teacher_Id);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
