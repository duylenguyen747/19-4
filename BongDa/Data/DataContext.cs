using BongDa.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BongDa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanBong_KieuSan>().HasKey(s => new
            {
                s.KieuSanId,
                s.SanBongId
            });
            modelBuilder.Entity<SanBong_KieuSan>() // thực thể SBKS chỉ quan hệ với 1 kiểu sân và qh nhiều với sanbong_kieusan 
                .HasOne(k => k.KieuSan)
                .WithMany(sk => sk.SanBong_KieuSans)
                .HasForeignKey(k => k.KieuSanId);

            modelBuilder.Entity<SanBong_KieuSan>() // thực thể SBKS chỉ quan hệ với 1 Sân bóng và qh nhiều với sanbong_kieusan 
                .HasOne(s => s.SanBong)
                .WithMany(sk => sk.SanBong_KieuSans)
                .HasForeignKey(k => k.SanBongId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SanBong> SanBongs { get; set;}
        public DbSet<KieuSan> KieuSans { get; set;}
        public DbSet<Khach> Khachs { get; set;}
        public DbSet<LichDatSan> LichDatSans { get; set;}
        public DbSet<SanBong_KieuSan> SanBong_KieuSans { get; set;}
    }
}
