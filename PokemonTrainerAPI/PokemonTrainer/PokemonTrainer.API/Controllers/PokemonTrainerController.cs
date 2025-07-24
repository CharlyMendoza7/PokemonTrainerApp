using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Application.UseCases;


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

        [Authorize]
        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _getAllUsersUseCase.ExecuteAsync();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("getUserLoginAccess")]
        public async Task<IActionResult> GetUserLogin(string username, string password)
        {
            var authenticatedUser = await _authenticateUserUseCase.ExecuteAsync(username, password);

            return authenticatedUser != null ? Ok(authenticatedUser) : Unauthorized();
        }

        [HttpPost("registerNewUser")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto, [FromServices] IValidator<RegisterUserDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            bool result = await _registerUserUseCase.ExecuteAsync(dto);

            return result ? Ok(result) : BadRequest("Invalid or duplicate user.");
        }
    }
}
