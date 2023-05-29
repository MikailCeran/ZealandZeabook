using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;
using ZealandBook.Services.Interface;
using ZealandBook.Services.SQLService;

namespace Zeabook.test
{
    [TestClass]
    public class TeacherTest
    {

        private TeacherService _teacherService;
        [TestInitialize]
        public void TestIntialize()
        {
            _teacherService= new TeacherService();
        }
        [TestMethod]
        public void GetTeacherById_Success()
        {
            // Arrange
            int teacherId = 1;

            try
            {
                // Act
                Teacher teacher = _teacherService.GetTeacherById(teacherId);

                // Assert
                Assert.IsNotNull(teacher, "Teacher should not be null");
                Assert.AreEqual(teacherId, teacher.TeacherID, "TeacherID should match the teacher's ID");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex}");
                //Testen som er angivet her bekræfter om ID som er givet i arrange, (teacherid =1)
                //Er gyldig, ved at angive bestemt ID.
            }
        }
        [TestMethod]
        public void GetBookingsForTeacherTest()
        {
            // Arrange
            int teacherId = 1;

            // Act
            List<Booking> bookings = _teacherService.GetBookingsForTeacher(teacherId);

            // Assert
            Assert.IsNotNull(bookings, "Bookings should not be null");
            Assert.IsTrue(bookings.Count > 0, "At least one booking should exist for the teacher");
            Assert.IsTrue(bookings.All(b => b.Teacher_Id == teacherId || b.Teacher_Id == null), "All bookings should belong to the specified teacher");
            Assert.IsFalse(bookings.Any(b => b.Teacher_Id == null), "No booking should have a null teacher ID");
            //Denne kode kontrollerer og fejlhåndterer bookinger med bestemt id for en teacher
        }
        [TestMethod]
        public void GetTeacherByEmailAndPasswordTest()
        {
            // Arrange
            List<Teacher> teachers = new List<Teacher>
    {
        new Teacher
        {
            TeacherID = 1,
            TeacherName = "Mikail Ceran",
            TeacherEmail = "mikailceran@example.com",
            Admin = false,
            Password = "password123"
        },
        new Teacher
        {
            TeacherID = 2,
            TeacherName = "Alperen dastan",
            TeacherEmail = "alpsendastansen@example.com",
            Admin = true,
            Password = "password456"
        }
    };

            string email = "mikailceran@example.com";
            string password = "password123";

            // Act
            Teacher teacher = teachers.FirstOrDefault(t => t.TeacherEmail == email && t.Password == password);

            // Assert
            Assert.IsNotNull(teacher, "Teacher should not be null");
            Assert.AreEqual(email, teacher.TeacherEmail, "Teacher email should match");
            Assert.AreEqual(password, teacher.Password, "Teacher password should match");
            //I dette eksempel opretter vi en liste over lærere og søger efter en lærer med den angivne kombination af e-mail og adgangskode.





        }













    }
}
