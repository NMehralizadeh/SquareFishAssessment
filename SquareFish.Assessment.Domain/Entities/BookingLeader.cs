namespace SquareFish.Assessment.Domain.Entities
{
    public class BookingLeader
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        
        public int LeaderId { get; set; }
        public Leader Leader { get; set; }
    }
}