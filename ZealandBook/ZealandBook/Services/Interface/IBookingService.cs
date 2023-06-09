﻿using ZealandBook.Models;

namespace ZealandBook.Services.Interface
{
    public interface IBookingService
    {
        public void CreateBooking(Booking booking);
        public List<Booking> GetAllBookings();

        public List<Booking> GetBookingsByStudentId(int student);
        public List<Booking> GetBookingsByTeacherId(int id);

        Booking GetBookingById(int id); 

        void DeleteBooking(int bookingId);

        public List<int> GetAllAvailableRoomIds(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo);

        public Room GetRoomById(int roomId);

        public void DeleteBookingsBeforeToday();

        public bool HasExistingBookingTeacher(int teacherId);
        public bool HasExistingBookingStudent(int studentId);

    }
}
