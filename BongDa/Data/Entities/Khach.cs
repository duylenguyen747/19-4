using System.ComponentModel.DataAnnotations;

namespace BongDa.Data.Entities
{
    public class Khach
    {
        [Key] public int Id { get; set; }
        public string? Ten { get; set; }
        public int SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }

        public List<SanBong> sanBongs { get; set; }
    }
}
