using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandBook.Models;
using ZealandBook.Services.ADONETService;
using ZealandBook.Services.Interface;

namespace Zeabook.test
{
    [TestClass]
    public class StudentTest
    {
        private StudentService _studentService;

        [TestInitialize]
        public void TestIntialize()
        {
            _studentService = new StudentService();
        }
        [TestMethod]
        public void GetBookingsForStudentTest()
        {
            int studentId = 1; 

            List<Booking> bookings = _studentService.GetBookingsForStudent(studentId);

            Assert.IsNotNull(bookings, "Bookings should not be null");
            Assert.IsTrue(bookings.Count > 0, "At least one booking should exist for the student");
            Assert.IsTrue(bookings.All(b => b.Student_Id == studentId || b.Student_Id == null), "All bookings should belong to the specified student");
            Assert.IsFalse(bookings.Any(b => b.Student_Id == null), "No booking should have a null student ID");

            //Denne test sikrer, at der findes mindst én booking for den angivne elev, og at alle bookings tilhører den specificerede elev.
        }

        [TestMethod]
        public void GetStudentById_Success()
        {
            // Arrange
            int studentId = 1; 

            try
            {
                // Act
                Student student = _studentService.GetStudentById(studentId);

                // Assert
                Assert.IsNotNull(student, "Student should not be null");
                Assert.AreEqual(studentId, student.StudentId, "Student ID should match the specified ID");
                // Add more assertions to check other properties of the student if needed
            }
            catch (Exception ex)
            {
                Assert.Fail($"An unexpected exception occurred: {ex}");
            }
            //Denne test bekræfter at getstudentbyid retuernererr en gyldig
            //student ved at angive en bestemt ID
        }
        [TestMethod]
        public void TestGetAllStudents()
        {
            // Act
            List<Student> students= _studentService.GetAllStudents();

            // Assert
            Assert.IsNotNull(students, "Should not be null");
            Assert.IsTrue(students.Count > 1, "At least one booking exist");

            //Denne test sikrer, at der findes mindst én elev og at listen over elever ikke er tom.
        }





    }
}
