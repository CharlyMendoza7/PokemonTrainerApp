using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Application.UseCases
{
    public class AuthenticateUserUseCase
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtGenerator;

        public AuthenticateUserUseCase(IUserRepository repo, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repo = repo;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticatedUserDto?> ExecuteAsync(string username, string rawPassword)
        {
            Console.WriteLine("username is: ", username);
            Console.WriteLine("rawpassword is: ", rawPassword);
            var user = await _repo.GetByUsernameAsync(username);
            if (user == null) return null;

            Console.WriteLine("user is: ", user);
            var hash = _passwordHasher.Hash(rawPassword);
            Console.WriteLine("hashpassword is: ", hash);
            if (user.PasswordHash != hash) return null;

            string token = _jwtGenerator.GenerateToken(user.UserID, user.UserName, user.Permission);

            return new AuthenticatedUserDto
            {
                Token = token,
                UserName = user.UserName
            };
        }
    }
}
