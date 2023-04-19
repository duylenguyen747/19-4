using BongDa.Data;
using BongDa.Data.Entities;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanBongController : ControllerBase
    {
        private readonly DataContext _context;

        public SanBongController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            // Cho 1 sanbong = lấy từ Sanbongs vào Danh sách
            var dssanbong = _context.SanBongs.ToList();

            // Yêu cầu thành công trả về thông báo 200(OK) 
            return Ok(dssanbong);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cho 1 nhân viên = lấy từ nhanviens lấy 1 hoặc lấy mặc định (nhanvien từ nhanvien.lấy từ mãNV bằng với id
            var sanbong = _context.SanBongs.SingleOrDefault(dh => dh.Id == id);

            // nếu nhân viên khác không thì trả về nhanvien
            // còn không thì trả về 404(not found) không tìm được giá trị yêu cầu
            if (sanbong != null)
            {
                return Ok(sanbong);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(SanBongRequest request)
        {
            try
            {
                var sanbong = new SanBong
                {
                    TenSan = request.TenSan,
                    Ngay = request.Ngay,
                    ThoiGian = request.ThoiGian,
                    Gia = request.Gia,
                    Loaisan = request.Loaisan,
                };
                _context.Add(sanbong);
                _context.SaveChanges();
                return Ok(sanbong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, SanBongRequest request)
        {
            var sanbong = _context.SanBongs.SingleOrDefault(sb => sb.Id == id);
            if (sanbong != null)
            {
                sanbong.TenSan = request.TenSan;
                sanbong.Ngay = request.Ngay;
                sanbong.ThoiGian = request.ThoiGian;
                sanbong.Gia = request.Gia;
                sanbong.Loaisan = request.Loaisan;
               
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
            var sanbong = _context.SanBongs.Find(id);
            if (sanbong == null)
                return (NotFound());
            _context.SanBongs.Remove(sanbong);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

