using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceBooking
    {
            private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            public static void CreateBooking(Booking booking)
            {
                string query = $"INSERT into Booking(Date_From,Date_To,Student_Id, Teacher_Id,Room_Id) Values(@Date_From,@Date_To,@Student_Id, @Teacher_Id,@Room_Id)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date_From", booking.DateFrom);
                        command.Parameters.AddWithValue("@Date_To", booking.DateTo);
                        command.Parameters.AddWithValue("@Student_Id", booking.Student_Id);
                        command.Parameters.AddWithValue("@Teacher_Id", booking.Teacher_Id);
                        command.Parameters.AddWithValue("@Room_Id", booking.Room_Id);
                        int affectedRows = command.ExecuteNonQuery();
                    }
                }
        }
    }
}
