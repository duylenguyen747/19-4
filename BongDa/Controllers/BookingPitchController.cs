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
    public class BookingPitchController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingPitchController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookingPitch()
        {
            var result = await (
                from bp in _context.BookingPitches
                join b in _context.Bookings //Join từ bookingpitch qua booking
                on bp.BookingId equals b.Id //điều kiện Join
                join p in _context.Pitchs // Join từ pitch qua bp
                on bp.PitchId equals p.Id
                select new
                {
                    PitchId = p.Id,
                    NamePitch = p.NamePitch,
                    NumberPitch = p.NumberPitch,
                    Description = p.Description,
                    Booking = string.Format("{0} {1} {2}", b.Name,b.DateTime,b.Price)
                }).ToListAsync(); // Khởi tạo 1 đối tượng để lấy thông tin
            

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingPitchDTO requestBP)
        {
            var bp = new BookingPitch()
            {
                BookingId = requestBP.BookingId,
                PitchId = requestBP.PitchId,
            };
            _context.BookingPitches.Add(bp);
            await _context.SaveChangesAsync();
            return Ok("Thiết lập thông tin sân bóng và đặt lịch thành công!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookingPitchDTO requestBP)
        {
            var bookingpitch = await _context.BookingPitches.FindAsync();
            if (bookingpitch == null) return NotFound("Không tìm thấy sân bóng");

            bookingpitch.BookingId = requestBP.BookingId;
            bookingpitch.PitchId = requestBP.PitchId;
            

            await _context.SaveChangesAsync();
            //         //204 không có nội dung để gửi yêu cầu nhưng nó vẫn hữu ích
            return Ok(bookingpitch);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var bookingpitch = await _context.BookingPitches.FindAsync();
            if (bookingpitch == null)
                return NotFound("Không tìm thấy Sân bóng");

            _context.BookingPitches.Remove(bookingpitch);
            await _context.SaveChangesAsync();
            return Ok("Sân bóng đã được xóa");
        }
    }
}
