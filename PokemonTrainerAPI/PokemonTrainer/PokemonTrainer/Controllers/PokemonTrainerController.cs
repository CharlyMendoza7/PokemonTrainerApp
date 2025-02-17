using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokemonTrainer.Data;
using PokemonTrainer.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PokemonTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class PokemonTrainerController : ControllerBase
    {
        private readonly PokemonTrainerDbContext _context;

        public PokemonTrainerController(PokemonTrainerDbContext context)
        {
            this._context = context;
        }


        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("getUserLoginAccess")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserLogin(string username, string password)
        {

            var hashPassInserted = HashPasswordSHA256(password);

            var user = await _context.Users.Where(x => x.UserName == username && x.PasswordHash == hashPassInserted).FirstOrDefaultAsync();

            if(user == null) { return Ok(false); }

            return Ok(user);
        }

        [HttpPost("registerNewUser")]
        public async Task<ActionResult<IEnumerable<User>>> InsertUser(User user)
        {
            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.PasswordHash) || !user.Birth.HasValue)
            {
                return BadRequest(HttpStatusCode.BadRequest);
            }

            string hashedPassword = HashPasswordSHA256(user.PasswordHash);
            var model = new User
            {
                UserName = user.UserName,
                PasswordHash = hashedPassword,
                Email = user.Email,
                Birth = user.Birth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Permission = "user"
            };

            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        private string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Convert to hex string
            }
        }
    }
}
