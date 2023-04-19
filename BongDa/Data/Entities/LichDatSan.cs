using System.ComponentModel.DataAnnotations;

namespace BongDa.Data.Entities
{
    public class LichDatSan
    {

        [Key] public int Id { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime GioDat { get; set; }
        public string DiaChi { get; set; }
        public bool TinhTrangSan { get; set; }
        public double GiaTien { get; set; }

        //Relationship
        public List<SanBong> sanBongs { get; set; }
    }
}
