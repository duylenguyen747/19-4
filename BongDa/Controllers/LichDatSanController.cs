using BongDa.Data.Entities;
using BongDa.Data;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichDatSanController : ControllerBase
    {
        private readonly DataContext _context;

        public LichDatSanController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // Cho 1 sanbong = lấy từ Sanbongs vào Danh sách
            var dslichdat = _context.LichDatSans.ToList();

            // Yêu cầu thành công trả về thông báo 200(OK) 
            return Ok(dslichdat);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cho 1 nhân viên = lấy từ nhanviens lấy 1 hoặc lấy mặc định (nhanvien từ nhanvien.lấy từ mãNV bằng với id
            var lichdat = _context.LichDatSans.SingleOrDefault(l => l.Id == id);

            // nếu nhân viên khác không thì trả về nhanvien
            // còn không thì trả về 404(not found) không tìm được giá trị yêu cầu
            if (lichdat != null)
            {
                return Ok(lichdat);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(LichDatSanRequest request)
        {
            try
            {
                var lichdatsan = new LichDatSan
                {
                    NgayDat = request.NgayDat,
                    GioDat = request.GioDat,
                    DiaChi = request.DiaChi,
                    TinhTrangSan = request.TinhTrangSan,
                    GiaTien = request.GiaTien,

                };
                _context.Add(lichdatsan);
                _context.SaveChanges();
                return Ok(lichdatsan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LichDatSanRequest request)
        {
            var lichdatsan = _context.LichDatSans.SingleOrDefault(l => l.Id == id);
            if (lichdatsan != null)
            {
                lichdatsan.NgayDat = request.NgayDat;
                lichdatsan.GioDat = request.GioDat;
                lichdatsan.DiaChi = request.DiaChi;
                lichdatsan.TinhTrangSan = request.TinhTrangSan;
                lichdatsan.GiaTien = request.GiaTien;

                _context.SaveChanges();
                // 204 không có nội dung để gửi yêu cầu nhưng nó vẫn hữu ích
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var lichdatsan = _context.LichDatSans.Find(id);
            if (lichdatsan == null)
                return (NotFound());
            _context.LichDatSans.Remove(lichdatsan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
