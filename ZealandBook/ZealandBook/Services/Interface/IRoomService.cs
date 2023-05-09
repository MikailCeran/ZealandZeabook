using ZealandBook.Models;
using ZealandBook.Services.SQLService;

namespace ZealandBook.Services.Interface
{
    public interface IRoomService
    {
        public List<Room> GetAllRooms();
       
        public void CreateRoom(Room room);
    }
}
