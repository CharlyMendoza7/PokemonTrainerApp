using PokemonTrainer.Domain.Entities;

namespace PokemonTrainer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task<IEnumerable<User>> GetAllAsync();
    }
}
