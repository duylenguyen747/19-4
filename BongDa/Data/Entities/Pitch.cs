namespace BongDa.Data.Entities
{
    public class Pitch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberPitch { get; set;}
        public string Description { get; set;}
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
