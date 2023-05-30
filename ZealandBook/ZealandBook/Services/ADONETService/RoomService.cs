using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class RoomService : IRoomService
    {
        public List<Room> GetAllRooms()
        {
            return SQLServiceRoom.GetAllRooms();
        }
        public void CreateRoom(Room room)
        {
            SQLServiceRoom.CreateRoom(room);
        }
        public  void UpdateRoomStatus(int rid)
        {
            SQLServiceRoom.UpdateRoomStatus(rid);
        }

        public int GetRoomId(int roomId)
        {
            return SQLServiceRoom.GetRoomId(roomId);
        }
        public List<Room> GetAllAvailableRooms()
        {
            return SQLServiceRoom.GetAllAvailableRooms();
        }
        //public void UpdateOccupiedStatusOfRooms()
        //{
        //    SQLServiceRoom.UpdateOccupiedStatusOfRooms();
        //}
    }
}
