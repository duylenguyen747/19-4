namespace BongDa.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public double Price { get; set; }
        public List<BookingPitch> BookingPitch { get; set; }
    }
}
