﻿using ZealandBook.Models;

namespace ZealandBook.Services.Interface
{
    public interface IBookingService
    {
        public void CreateBooking(Booking booking);
        public List<Booking> GetAllBookings();

        //public List<Booking> GetBookingsByStudentId(int studentId);
    }
}
