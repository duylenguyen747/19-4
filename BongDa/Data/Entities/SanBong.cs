using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BongDa.Data.Entities
{
    public class SanBong
    {
        public enum LoaiSans
        {
            San_5 = 1,
            San_7 = 2,
            San_11 = 3,
        }
        [Key] public int Id { get; set; }
        public string TenSan { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime ThoiGian { get; set; }
        public double Gia { get; set; }
        public LoaiSans Loaisan { get; set; }

        // nhiều nhiều
        public List<SanBong_KieuSan> SanBong_KieuSans { get; set; }


        // một nhiều
        public Khach Khach { get; set; }
        [ForeignKey("KhachId")] public int KhachId { get; set; }


        public LichDatSan LichDatSan { get; set; }
        [ForeignKey("LichDatSan")] public int LichDatSanId { get; set; }
    }
}
