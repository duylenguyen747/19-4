using BongDa.Data;
using BongDa.Data.Entities;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BongDa.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class PitchController : ControllerBase
    {
        private readonly DataContext _context;

        public PitchController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetPitch()
        {
            //hiển thị cả tên và các thông tin cần lấy, sử dụng join trong linq
            var result = await(
                from p in _context.Pitchs //từ sân bóng
                join u in _context.Users // join đến người dùng
                on p.UserId equals u.Id
                select new
                {
                    Id = p.Id,
                    Name = p.NamePitch,
                    NumberPitch = p.NumberPitch,
                    Description = p.Description,
                    User = string.Format("{0} {1} {2} {3}",u.Number, u.Name,u.Age,u.Address)
                }
                ).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pitch = await _context.Pitchs.FindAsync(id);
            if (pitch == null)
            {
                return NotFound("Không tìm thấy sân bóng");
            }
            return Ok(pitch);
        }
        [HttpPost]
        public async Task<IActionResult> Created(PitchDTO request)
        {
            var pitch = new Pitch()
            {
                Id = new int(),
                NamePitch = request.NamePitch,
                NumberPitch = request.NumberPitch,
                Description = request.Description,
                UserId = request.UserId
            };
            _context.Pitchs.Add(pitch);
            await _context.SaveChangesAsync();
            return Ok(pitch);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, PitchDTO request)
        {
            var pitch = await _context.Pitchs.FindAsync(id);
            if (pitch == null) return NotFound("Không tìm thấy sân bóng");

            pitch.NamePitch = request.NamePitch;
            pitch.NumberPitch = request.NumberPitch;
            pitch.Description = request.Description;
            pitch.UserId = request.UserId;  

            await _context.SaveChangesAsync();
            //         //204 không có nội dung để gửi yêu cầu nhưng nó vẫn hữu ích
            return Ok(pitch);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id) 
        {
            var pitch = await _context.Pitchs.FindAsync(id);
            if (pitch == null)
                return NotFound("Không tìm thấy Sân bóng");


            var count = await _context.Users.CountAsync(x => x.Id == id);
            if (count > 0) return BadRequest("Không thể xóa khi đã có người đặt sân");

            _context.Pitchs.Remove(pitch);
            await _context.SaveChangesAsync();
            return Ok("Sân bóng đã được xóa");
        }
    }
 }


