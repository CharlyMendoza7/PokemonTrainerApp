using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Application.UseCases
{
    public class AuthenticateUserUseCase
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateUserUseCase(IUserRepository repo, IPasswordHasher passwordHasher)
        {
            _repo = repo;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticatedUserDto?> ExecuteAsync(string username, string rawPassword)
        {

            var user = await _repo.GetByUsernameAsync(username);
            if (user == null) return null;

            var hash = _passwordHasher.Hash(rawPassword);
            if (user.PasswordHash != hash) return null;

            return new AuthenticatedUserDto
            {
                Id = user.UserID,
                UserName = user.UserName,
                Role = user.Permission
            };
        }
    }
}
