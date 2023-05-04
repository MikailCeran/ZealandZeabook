using System.Data.SqlClient;
using ZealandBook.Models;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceRoom
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void CreateRoom(Room room)
        {
            string query = $"INSERT into Room(Room_Type,Room_Size,Smartboard,Building,Description) Values(@Room_Type,@Room_Size,@Smartboard,@Building,@Description)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Room_Type", room.Room_Type);
                    command.Parameters.AddWithValue("@Room_Size", room.Room_Size);
                    command.Parameters.AddWithValue("@Smartboard", room.RoomFacilities);
                    command.Parameters.AddWithValue("@Building", room.Building);
                    command.Parameters.AddWithValue("@Description", room.Description);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
