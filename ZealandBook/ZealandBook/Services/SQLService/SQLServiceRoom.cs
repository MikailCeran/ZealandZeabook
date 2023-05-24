using ZealandBook.Models;
using Microsoft.Data.SqlClient;
using ZealandBook.Services.ADONETService;
using System.Security.Cryptography;

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
                        room.Room_Name= Convert.ToString(reader[6]);
                        rooms.Add(room);

                    }
                }
            }
            return rooms;
        }
        public static void CreateRoom(Room room)
        {
            string query = $"INSERT into Room(Room_Type, Room_Size, Smartboard, Building, Description, Room_Name, Occupied) Values(@Room_Type, @Room_Size, @Smartboard, @Building, @Description, @Room_Name, @Occupied)";
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
                    command.Parameters.AddWithValue("@Room_Name", room.Room_Name);
                    command.Parameters.AddWithValue("@Occupied", room.Occupied);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateRoomStatus(int rid)
        {
            string query = $"Update Room set Room.Occupied =1 where Room.Room_Id = {rid}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@rid", rid);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

        public static int GetRoomId(int roomId)
        {
            string query = $"select Room_Id from Room";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(@query, connection))
                {
                    
                    return roomId;
                }
            }
        }
        public static List<Room> GetAllAvailableRooms()
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM Room WHERE Occupied = 0";
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
                        room.Room_Type = Convert.ToString(reader[1]);
                        room.Room_Size = Convert.ToString(reader[2]);
                        room.RoomFacilities = Convert.ToString(reader[3]);
                        room.Building = Convert.ToString(reader[4]);
                        room.Description = Convert.ToString(reader[5]);
                        room.Room_Name = Convert.ToString(reader[6]);
                        rooms.Add(room);

                    }
                }
            }
            return rooms;
        }

    }
}