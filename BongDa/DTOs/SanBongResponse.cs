using static BongDa.Data.Entities.SanBong;

namespace BongDa.DTOs
{
    public class SanBongResponse
    {
        public string TenSan { get; set; }
        public DateTime Ngay { get; set; }
        public string ThoiGian { get; set; }
        public double Gia { get; set; }
    }
}
