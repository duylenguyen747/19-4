using BongDa.Data.Entities;
using BongDa.Data;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private readonly DataContext _context;

        public KhachController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // Cho 1 sanbong = lấy từ Sanbongs vào Danh sách
            var dskhach = _context.Khachs.ToList();

            // Yêu cầu thành công trả về thông báo 200(OK) 
            return Ok(dskhach);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cho 1 nhân viên = lấy từ nhanviens lấy 1 hoặc lấy mặc định (nhanvien từ nhanvien.lấy từ mãNV bằng với id
            var khach = _context.Khachs.SingleOrDefault(k => k.Id == id);

            // nếu nhân viên khác không thì trả về nhanvien
            // còn không thì trả về 404(not found) không tìm được giá trị yêu cầu
            if (khach != null)
            {
                return Ok(khach);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(KhachRequest request)
        {
            try
            {
                var khach = new Khach
                {
                    Ten = request.Ten,
                    DiaChi = request.DiaChi,
                    SoDienThoai = request.SoDienThoai,
                    NgaySinh = request.NgaySinh,
                };
                _context.Add(khach);
                _context.SaveChanges();
                return Ok(khach);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, KhachRequest request)
        {
            var khach = _context.Khachs.SingleOrDefault(k => k.Id == id);
            if (khach != null)
            {
                khach.Ten = request.Ten;
                khach.DiaChi = request.DiaChi;
                khach.SoDienThoai = request.SoDienThoai;
                khach.NgaySinh = request.NgaySinh;
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
            var khach = _context.Khachs.Find(id);
            if (khach == null)
                return (NotFound());
            _context.Khachs.Remove(khach);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
