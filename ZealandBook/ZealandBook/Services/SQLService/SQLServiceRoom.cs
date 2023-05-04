using ZealandBook.Models;
using Microsoft.Data.SqlClient;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceRoom
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void CreateRoom(Room room)
        {
            string query = $"INSERT into Room(RoomID, RoomType, RoomFacilities, RoomSize, Building, Description) Values(@RoomID, @RoomType, @RoomFacilities, @RoomSize, @Building, @Description)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("RoomID", room.Room_ID);
                    command.Parameters.AddWithValue("@RoomType", room.Room_Type);
                    command.Parameters.AddWithValue("@RoomFacilities", room.RoomFacilities);
                    command.Parameters.AddWithValue("@RoomSize", room.Room_Size);
                    command.Parameters.AddWithValue("@Building", room.Building);
                    command.Parameters.AddWithValue("@Description", room.Description);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}