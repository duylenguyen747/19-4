using BongDa.Data.Entities;
using BongDa.Data;
using BongDa.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BongDa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            //hiển thị cả tên và các thông tin cần lấy, sử dụng join trong linq
            var result = await (
                from u in _context.Users //từ Người dùng
                join p in _context.Pitchs // join đến Sân bóng
                on u.Id equals p.UserId
                select new
                {
                    Id = u.Id,
                    Name = u.Name,
                    Age = u.Age,
                    Number = u.Number,
                    Address = u.Address,
                    Pitch = string.Format("{0} {1} ", p.NamePitch, p.NumberPitch)
                }
                ).ToListAsync();
            return Ok(result);
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound("Không tìm thấy người dùng");
        //    }
        //    return Ok(user);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO RequestUser)
        {

            var user = new User()
            {
                Id = new int(),
                Name = RequestUser.Name,
                Age = RequestUser.Age,
                Number = RequestUser.Number,
                Address = RequestUser.Address,
                
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateById(int id, UserDTO RequestUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("Không tìm thấy người dùng");

            user.Name = RequestUser.Name;
            user.Age = RequestUser.Age;
            user.Number = RequestUser.Number;
            user.Address = RequestUser.Address;
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("Không tìm thấy người dùng");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("Người dùng đã được xóa!");
        }
    }
}

