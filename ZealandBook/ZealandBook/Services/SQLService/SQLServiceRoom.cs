using ZealandBook.Models;
using Microsoft.Data.SqlClient;
using ZealandBook.Services.ADONETService;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceRoom
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            string query = "Select * from Room";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.Room_ID = Convert.ToInt32(reader[0]);
                        room.Room_Type= Convert.ToString(reader[1]);
                        room.Room_Size= Convert.ToString(reader[2]);
                        room.RoomFacilities= Convert.ToString(reader[3]);
                        room.Building= Convert.ToString(reader[4]);
                        room.Description= Convert.ToString(reader[5]);
                        rooms.Add(room);

                    }
                }
            }
            return rooms;
        }
        public static void CreateRoom(Room room)
        {
            string query = $"INSERT into Room(Room_Type, Room_Size, Smartboard, Building, Description) Values(@Room_Type, @Room_Size, @Smartboard, @Building, @Description)";
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