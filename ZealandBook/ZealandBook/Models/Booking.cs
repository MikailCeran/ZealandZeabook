namespace ZealandBook.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public TimeSpan DateFrom { get; set; }
        public TimeSpan DateTo { get; set; }

        public DateTime Date { get; set; }


        

        //Foreign keys
        public int? Student_Id { get; set; }
        public int? Teacher_Id{ get; set; }
        public int Room_Id { get; set; }
     


    }
}
