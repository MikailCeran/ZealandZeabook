using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;
using ZealandBook.Services.SQLService;

namespace Zeabook.test
{
    [TestClass]
    public class RoomTest
    {
        private SQLServiceRoom _roomService;
        private RoomService _roomServices;

        [TestInitialize]
        public void RoomIntialize()
        {
            _roomService = new SQLServiceRoom();
            _roomServices = new RoomService();
        }

        [TestMethod]
        public void TestRoomOccupied()
        {
            // Act
            List<Room> rooms = _roomServices.GetAllAvailableRooms();

            // Assert
            Assert.IsNotNull(rooms, "Rooms should not be null");
            Assert.IsTrue(rooms.Count > 1, "At least one available room should exist");

            //Denne testmetode bekræfter, at GetAllAvailableRooms-metoden
            //returnerer en ikke-null liste af ledige lokaler,
            //og mindst ét lokale forventes at være tilgængeligt.
        }
        [TestMethod]
        public void TestGetRoomId_Exists()
        {
            // Arrange
            int roomId = 1; 

            // Act
            int result = _roomServices.GetRoomId(roomId);

            // Assert
            Assert.AreEqual(roomId, result, $"Room ID {roomId} should exist");
            
            //TestGetRoomId_Exists bekræfter, at en room - id eksisterer
            //i systemet ved hjælp af `GetRoomId`-metoden.
            //Den tester så om en specifik roomid findes, metoden er god til at tjek om der SQL data.
        }
        [TestMethod]
        public void TestUpdateOccupiedStatusOfRooms()
        {

            _roomServices.UpdateOccupiedStatusOfRooms();

            
            List<Room> updatedRooms = _roomServices.GetAllRooms();
            bool allRoomsOccupiedStatusUpdated = updatedRooms.All(room => room.Occupied == false);

            Assert.IsTrue(allRoomsOccupiedStatusUpdated, "Occupied status of rooms should be updated to 0(false)");
            //Denne testmetode er for at bekræfte korrekt opdatering
            //af værelsernes occupied status, hvor metoden UpdateOccupiedStatusOfRooms-metoden bruges.

        }





    }
}
