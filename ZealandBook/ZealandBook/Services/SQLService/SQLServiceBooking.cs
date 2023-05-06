﻿using ZealandBook.Models;
using Microsoft.Data.SqlClient;
using ZealandBook.Services.ADONETService;

namespace ZealandBook.Services.SQLService
{
    public class SQLServiceBooking
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ZeabookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            string query = "Select * from Booking";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking book= new Booking();
                        book.BookingID = Convert.ToInt32(reader[0]);
                        book.DateFrom = Convert.ToDateTime(reader[1]);
                        book.DateTo = Convert.ToDateTime(reader[2]);
                        book.Student_Id= Convert.ToInt32(reader[3]);
                        book.Teacher_Id= Convert.ToInt32(reader[4]);
                        book.Room_Id= Convert.ToInt32(reader[5]);
                        bookings.Add(book);
                       
                    }
                }
            }
            return  bookings;
        }
        public static void CreateBooking(Booking booking)
        {
            string query = $"INSERT into Booking(Date_From,Date_To,Student_Id, Teacher_Id,Room_Id) Values(@Date_From,@Date_To,@Student_Id, @Teacher_Id,@Room_Id)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date_From", booking.DateFrom);
                    command.Parameters.AddWithValue("@Date_To", booking.DateTo);
                    command.Parameters.AddWithValue("@Student_Id", booking.Student_Id);
                    command.Parameters.AddWithValue("@Teacher_Id", booking.Teacher_Id);
                    command.Parameters.AddWithValue("@Room_Id", booking.Room_Id);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        
    }
    
}
