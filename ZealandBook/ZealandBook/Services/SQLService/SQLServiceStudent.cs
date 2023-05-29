using ZealandBook.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceStudent
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void CreateStudent(Student student)
        {
            string query = $"INSERT into Student(Name, Email, Password) Values(@Name, @Email, @Password)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.StudentName);
                    command.Parameters.AddWithValue("@Email", student.StudentEmail);
                    command.Parameters.AddWithValue("@PasswordHasher", student.Password);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string query = "Select * from Booking";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.StudentId = Convert.ToInt32(reader[0]);
                        student.StudentName = Convert.ToString(reader[1]);
                        student.StudentEmail = Convert.ToString(reader[2]);
                        student.Password = Convert.ToString(reader[3]);
                        students.Add(student);

                    }
                }
            }
            return students;
        }

        public static Student GetStudentByEmailAndPassword(string email, string password)
        {
            string query = "SELECT * FROM Student WHERE Email = @Email AND Password = @Password";
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
                            Student student = new Student();
                            student.StudentId = Convert.ToInt32(reader[0]);
                            student.StudentName = Convert.ToString(reader[1]);
                            student.StudentEmail = Convert.ToString(reader[2]);
                            student.Password = Convert.ToString(reader[3]);
                            return student;
                        }
                    }
                }
            }
            return null;
        }

        public static List<Booking> GetBookingsForStudent(int studentId)
        {
            string query = "SELECT * FROM Booking WHERE Student_Id = @StudentId";
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(reader["Booking_Id"]);
                            booking.DateFrom = TimeSpan.Parse(reader["Date_From"].ToString());
                            booking.DateTo = TimeSpan.Parse(reader["Date_To"].ToString());
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

        public static Student GetStudentById(int studentId)
        {
            string query = "SELECT * FROM Student WHERE Student_Id = @StudentId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Student student = new Student();
                            student.StudentId = Convert.ToInt32(reader["Student_Id"]);
                            student.StudentName = reader["Name"].ToString();
                            student.StudentEmail = reader["Email"].ToString();
                            student.Password = reader["Password"].ToString();
                            return student;
                        }
                    }
                }
            }
            return null; // Return null if the student is not found
        }


    }
}