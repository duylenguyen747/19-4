namespace BongDa.Data.Entities
{
    public class SanBong_KieuSan
    {
        public int KieuSanId { get; set; }
        public KieuSan KieuSan { get; set; }
        public int SanBongId { get; set; }
        public SanBong SanBong { get; set; }
    }
}
