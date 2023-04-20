using BongDa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BongDa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pitch> Pitchs { get; set; }
    }
}
