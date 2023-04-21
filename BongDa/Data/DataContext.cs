using BongDa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BongDa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingPitch>()
                .HasKey(k => new { k.PitchId, k.BookingId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pitch> Pitchs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingPitch> BookingPitches { get; set; }  
    }
}
