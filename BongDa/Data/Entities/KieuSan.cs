using System.ComponentModel.DataAnnotations;

namespace BongDa.Data.Entities
{
    public class KieuSan
    {

        [Key] public int Id { get; set; }

        public double GiaSan { get; set; }
        public List<SanBong_KieuSan> SanBong_KieuSans { get; set; }
    }
}
