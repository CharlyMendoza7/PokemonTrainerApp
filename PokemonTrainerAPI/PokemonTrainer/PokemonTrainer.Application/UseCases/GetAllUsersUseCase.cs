using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Application.UseCases
{
    public class GetAllUsersUseCase
    {
        private readonly IUserRepository _repo;

        public GetAllUsersUseCase(IUserRepository repo)
        {
            _repo = repo;
        }   

        public async Task<IEnumerable<User>> ExecuteAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
