namespace ZealandBook.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        //Foreign keys
        public int Student_Id { get; set; }
        public int Teacher_Id{ get; set; }
        public int Room_Id { get; set; }


    }
}
