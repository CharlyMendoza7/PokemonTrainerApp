﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Data;
using PokemonTrainer.Models;

namespace PokemonTrainer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("getUserLogin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserLogin(string username)
        {
            var user = await _context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            return Ok(user);
        }
    }
}
