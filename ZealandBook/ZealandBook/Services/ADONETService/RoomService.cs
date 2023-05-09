using ZealandBook.Models;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.ADONETService
{
    public class RoomService : IRoomService
    {
        public void CreateRoom(Room room)
        {
            SQLServiceRoom.CreateRoom(room);
        }
       
    }
}
