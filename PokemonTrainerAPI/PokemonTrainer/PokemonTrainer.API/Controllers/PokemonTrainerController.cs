using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Application.UseCases;
using PokemonTrainer.Data;
using PokemonTrainer.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PokemonTrainer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class PokemonTrainerController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly AuthenticateUserUseCase _authenticateUserUseCase;
        private readonly GetAllUsersUseCase _getAllUsersUseCase;

        public PokemonTrainerController(RegisterUserUseCase registerUserUseCase, AuthenticateUserUseCase authenticateUserUseCase, GetAllUsersUseCase getAllUsersUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _authenticateUserUseCase = authenticateUserUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;

        }


        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _getAllUsersUseCase.ExecuteAsync();

            return Ok(users);
        }

        [HttpGet("getUserLoginAccess")]
        public async Task<IActionResult> GetUserLogin(string username, string password)
        {

            var user = await _authenticateUserUseCase.ExecuteAsync(username, password);

            return user != null ? Ok(user) : Unauthorized();
        }

        [HttpPost("registerNewUser")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            bool result = await _registerUserUseCase.ExecuteAsync(dto);

            return result ? Ok(result) : BadRequest("Invalid or duplicate user.");
        }
    }
}
