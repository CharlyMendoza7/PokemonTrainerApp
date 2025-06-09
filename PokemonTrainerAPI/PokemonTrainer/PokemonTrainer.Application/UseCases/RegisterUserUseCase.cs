using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;
using System.Net;

namespace PokemonTrainer.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _hasher;

        public RegisterUserUseCase(IUserRepository repo, IPasswordHasher hasher)
        {
            _repo = repo;
            _hasher = hasher;
        }

        public async Task<bool> ExecuteAsync(RegisterUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.UserName) || string.IsNullOrEmpty(dto.Password) || !dto.Birth.HasValue)
            {
                return false;
            }

            var existingUser = await _repo.GetByUsernameAsync(dto.UserName);
            if (existingUser != null) return false;

            var user = new User 
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Birth = dto.Birth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Permission = "user"
            };

            user.SetPassword(dto.Password, _hasher);

            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
