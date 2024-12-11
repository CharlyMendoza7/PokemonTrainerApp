using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Data;
using PokemonTrainer.Models;

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
            var user = await _context.Users.Where(x => x.UserName == username && x.PasswordHash == password).FirstOrDefaultAsync();

            if(user == null) { return Ok(false); }

            return Ok(user);
        }
    }
}
