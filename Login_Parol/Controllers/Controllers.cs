using Login_Parol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLoginApi.Data;


namespace UserLoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
         
        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return StatusCode(409, "User already exists");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return StatusCode(201, "User created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
            {
                return StatusCode(404, "Invalid username or password");
            }

            return Ok("Login successful");
        }
    }
}
