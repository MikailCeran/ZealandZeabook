using ZealandBook.Models;
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
            string query = "SELECT * FROM Booking";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking book = new Booking();
                            book.BookingID = Convert.ToInt32(reader[0]);
                            book.DateFrom = Convert.ToDateTime(reader[1]);
                            book.DateTo = Convert.ToDateTime(reader[2]);

                            if (!reader.IsDBNull(3))
                                book.Student_Id = Convert.ToInt32(reader[3]);
                            else
                                book.Student_Id = null;

                            if (!reader.IsDBNull(4))
                                book.Teacher_Id = Convert.ToInt32(reader[4]);
                            else
                                book.Teacher_Id = null;

                            book.Room_Id = Convert.ToInt32(reader[5]);

                            bookings.Add(book);
                        }
                    }
                }
            }

            return bookings;
        }

        public static void CreateBooking(Booking booking)
        {
            string query = "INSERT INTO Booking (Date_From, Date_To, Student_Id, Teacher_Id, Room_Id) " +
                           "VALUES (@Date_From, @Date_To, @Student_Id, @Teacher_Id, @Room_Id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date_From", booking.DateFrom);
                    command.Parameters.AddWithValue("@Date_To", booking.DateTo);

                    command.Parameters.AddWithValue("@Student_Id", booking.Student_Id.HasValue ? (object)booking.Student_Id.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@Teacher_Id", booking.Teacher_Id.HasValue ? (object)booking.Teacher_Id.Value : DBNull.Value);

                    command.Parameters.AddWithValue("@Room_Id", booking.Room_Id);

                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }


        public static List<Booking> GetBookingsByStudentId(int student)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Booking WHERE Student_Id = @StudentId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", student);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(reader["Booking_Id"]);
                            booking.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                            booking.DateTo = Convert.ToDateTime(reader["Date_To"]);

                            if (!reader.IsDBNull(reader.GetOrdinal("Student_Id")))
                                booking.Student_Id = Convert.ToInt32(reader["Student_Id"]);
                            else
                                booking.Student_Id = null;

                            if (!reader.IsDBNull(reader.GetOrdinal("Teacher_Id")))
                                booking.Teacher_Id = Convert.ToInt32(reader["Teacher_Id"]);
                            else
                                booking.Teacher_Id = null;

                            booking.Room_Id = Convert.ToInt32(reader["Room_Id"]);

                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }

        public static List<Booking> GetBookingsByTeacherId(int id)
        {
            List<Booking> bookings = new List<Booking>();
            string query = "SELECT * FROM Booking WHERE Teacher_Id = @TeacherId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingID = Convert.ToInt32(reader["Booking_Id"]);
                            booking.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                            booking.DateTo = Convert.ToDateTime(reader["Date_To"]);
                            booking.Teacher_Id = Convert.ToInt32(reader["Teacher_Id"]);
                            booking.Room_Id = Convert.ToInt32(reader["Room_Id"]);
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return bookings;
        }


        public static void DeleteBooking(int bookingId)
        {
            string query = "DELETE FROM Booking WHERE Booking_Id = @BookingId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingId", bookingId);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0)
                    {
                        throw new Exception("No booking found with the provided ID.");
                    }
                }
            }
        }


        public static Booking GetBookingById(int id)
        {
            Booking booking = null;
            string query = "SELECT * FROM Booking WHERE Booking_Id = @Booking_Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Booking_Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new Booking();
                            booking.BookingID = Convert.ToInt32(reader[0]);
                            booking.DateFrom = Convert.ToDateTime(reader[1]);
                            booking.DateTo = Convert.ToDateTime(reader[2]);
                            booking.Student_Id = Convert.ToInt32(reader[3]);
                            booking.Teacher_Id = Convert.ToInt32(reader[4]);
                            booking.Room_Id = Convert.ToInt32(reader[5]);
                        }
                    }
                }
            }
            return booking;
        }


        public static List<int> GetAllAvailableRoomIds(DateTime specificDate, TimeSpan specificTimeFrom, TimeSpan specificTimeTo)
        {
            List<int> roomIds = new List<int>();
            string query = "SELECT r.Room_Id FROM Room r LEFT JOIN Booking b ON r.Room_Id = b.Room_Id AND (CONVERT(DATE, b.[Date]) = @Specific_Date AND ((CAST(@Specific_Time_From AS TIME) >= b.Date_From AND CAST(@Specific_Time_From AS TIME) < b.Date_To) OR (CAST(@Specific_Time_To AS TIME) > b.Date_From AND CAST(@Specific_Time_To AS TIME) <= b.Date_To) OR (CAST(@Specific_Time_From AS TIME) <= b.Date_From AND CAST(@Specific_Time_To AS TIME) >= b.Date_To))) WHERE b.Booking_Id IS NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Specific_Date", specificDate.Date);
                    command.Parameters.AddWithValue("@Specific_Time_From", specificDate.Date + specificTimeFrom);
                    command.Parameters.AddWithValue("@Specific_Time_To", specificDate.Date + specificTimeTo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roomId = Convert.ToInt32(reader["Room_Id"]);
                            roomIds.Add(roomId);
                        }
                    }
                }
            }
            return roomIds;
        }

        public static Room GetRoomById(int roomId)
        {
            Room room = null;
            string query = "SELECT * FROM Room WHERE Room_Id = @RoomId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomId", roomId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            room = new Room
                            {
                                Room_ID = Convert.ToInt32(reader["Room_Id"]),
                                Room_Type = reader["Room_Type"] != DBNull.Value ? Convert.ToString(reader["Room_Type"]) : string.Empty,
                                Room_Size = reader["Room_Size"] != DBNull.Value ? Convert.ToString(reader["Room_Size"]) : string.Empty,
                                RoomFacilities = reader["Smartboard"] != DBNull.Value ? Convert.ToString(reader["Smartboard"]) : string.Empty,
                                Building = reader["Building"] != DBNull.Value ? Convert.ToString(reader["Building"]) : string.Empty,
                                Description = reader["Description"] != DBNull.Value ? Convert.ToString(reader["Description"]) : string.Empty,
                                Room_Name = reader["Room_Name"] != DBNull.Value ? Convert.ToString(reader["Room_Name"]) : string.Empty,
                                Occupied = reader["Occupied"] != DBNull.Value ? Convert.ToBoolean(reader["Occupied"]) : false
                            };
                        }
                    }
                }
            }

            return room;
        }





    }

}
