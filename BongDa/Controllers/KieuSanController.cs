using BongDa.Data.Entities;
using BongDa.Data;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KieuSanController : ControllerBase
    {
        private readonly DataContext _context;

        public KieuSanController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // Cho 1 sanbong = lấy từ Sanbongs vào Danh sách
            var dskieusan = _context.KieuSans.ToList();

            // Yêu cầu thành công trả về thông báo 200(OK) 
            return Ok(dskieusan);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cho 1 nhân viên = lấy từ nhanviens lấy 1 hoặc lấy mặc định (nhanvien từ nhanvien.lấy từ mãNV bằng với id
            var kieusan = _context.KieuSans.SingleOrDefault(ks => ks.Id == id);

            // nếu nhân viên khác không thì trả về nhanvien
            // còn không thì trả về 404(not found) không tìm được giá trị yêu cầu
            if (kieusan != null)
            {
                return Ok(kieusan);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(KieuSanRequest request)
        {
            try
            {
                var kieusan = new KieuSan
                {
                    GiaSan = request.GiaSan
                };
                _context.Add(kieusan);
                _context.SaveChanges();
                return Ok(kieusan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, KieuSanRequest request)
        {
            var kieusan = _context.KieuSans.SingleOrDefault(ks => ks.Id == id);
            if (kieusan != null)
            {
                kieusan.GiaSan = request.GiaSan;

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
            var kieusan = _context.KieuSans.Find(id);
            if (kieusan == null)
                return (NotFound());
            _context.KieuSans.Remove(kieusan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
