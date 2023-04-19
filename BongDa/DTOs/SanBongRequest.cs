using static BongDa.Data.Entities.SanBong;

namespace BongDa.DTOs
{
    public class SanBongRequest
    {
        public string TenSan { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime ThoiGian { get; set; }
        public double Gia { get; set; }
        public LoaiSans Loaisan { get; set; }
     }
}
