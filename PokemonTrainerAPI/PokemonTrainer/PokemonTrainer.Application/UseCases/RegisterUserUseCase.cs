using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;
using System.Net;

namespace PokemonTrainer.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _hasher;
        private readonly ITrainerProfileRepository _trainerProfileRepository;

        public RegisterUserUseCase(IUserRepository repo, IPasswordHasher hasher, ITrainerProfileRepository trainerProfileRepository)
        {
            _userRepository = repo;
            _hasher = hasher;
            _trainerProfileRepository = trainerProfileRepository;
        }

        public async Task<bool> ExecuteAsync(RegisterUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.UserName) || string.IsNullOrEmpty(dto.Password) || !dto.Birth.HasValue)
            {
                return false;
            }

            var existingUser = await _userRepository.GetByUsernameAsync(dto.UserName);
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

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            //create profile
            var profile = new TrainerProfile
            {
                UserId = user.UserID,
                DisplayName = user.UserName,
                Region = "Kanto", //TODO: default kanto for now but allow to chose later
                CreatedAt = DateTime.UtcNow,
                LastActive = DateTime.UtcNow,
            };

            await _trainerProfileRepository.AddAsync(profile);
            await _trainerProfileRepository.SaveChangesAsync();

            return true;
        }
    }
}
