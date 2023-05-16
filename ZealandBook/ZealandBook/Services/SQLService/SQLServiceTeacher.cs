using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceTeacher
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
        public static Teacher GetTeacherByEmailAndPassword(string email, string password)
        {
            string query = "SELECT * FROM Teacher WHERE Email = @Email AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Teacher teacher = new Teacher();
                            teacher.TeacherID= Convert.ToInt32(reader[0]);
                            teacher.TeacherName= Convert.ToString(reader[1]);
                            teacher.TeacherEmail= Convert.ToString(reader[2]);
                            teacher.Admin= Convert.ToBoolean(reader[3]);
                            teacher.Password= Convert.ToString(reader[4]);
                            return teacher;
                        }
                    }
                }
            }
            return null;
        }

        public static List<Booking> GetBookingsForTeacher(int id)
        {
            string query = "SELECT * FROM Booking WHERE Teacher_Id = @TeacherId";
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(reader["Booking_Id"]);
                            booking.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                            booking.DateTo = Convert.ToDateTime(reader["Date_To"]);
                            booking.Student_Id = Convert.ToInt32(reader["Student_Id"]);
                            booking.Teacher_Id = Convert.ToInt32(reader["Teacher_Id"]);
                            booking.Room_Id = Convert.ToInt32(reader["Room_Id"]);
                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }

        public static Teacher GetTeacherById(int id)
        {
            string query = "SELECT * FROM Teacher WHERE Teacher_Id = @TeacherId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Teacher teacher = new Teacher();
                            teacher.TeacherID= Convert.ToInt32(reader["Teacher_Id"]);
                            teacher.TeacherName = reader["Name"].ToString();
                            teacher.TeacherEmail = reader["Email"].ToString();
                            teacher.Admin = Convert.ToBoolean(reader["Admin"]);
                            teacher.Password = reader["Password"].ToString();
                            return teacher;
                        }
                    }
                }
            }
            return null; 
        }
      
    }
}
