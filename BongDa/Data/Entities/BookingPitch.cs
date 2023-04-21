namespace BongDa.Data.Entities
{
    public class BookingPitch
    {
        public int PitchId { get; set; }
        public Pitch Pitch { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
