using BongDa.Data.Entities;
using BongDa.Data;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            
            
                return Ok(await _context.Bookings.ToListAsync());
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound("Không tìm thấy sân bóng");
            }
            return Ok(booking);
        }
        [HttpPost]
        public async Task<IActionResult> Created(BookingDTO request)
        {
            var booking = new Booking()
            {
                Id = new int(),
                Name = request.Name,
                DateTime = request.DateTime,
                Price = request.Price,
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, BookingDTO request)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound("Không tìm thấy sân bóng");

            booking.Name = request.Name;
            booking.DateTime = request.DateTime;
            booking.Price = request.Price;

            await _context.SaveChangesAsync();
            //         //204 không có nội dung để gửi yêu cầu nhưng nó vẫn hữu ích
            return Ok(booking);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound("Không tìm thấy Sân bóng");


            
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok("Booking đã được xóa");
        }
    }
}


