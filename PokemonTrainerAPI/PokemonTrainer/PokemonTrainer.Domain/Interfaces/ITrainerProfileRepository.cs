

using PokemonTrainer.Domain.Entities;

namespace PokemonTrainer.Domain.Interfaces
{
    public interface ITrainerProfileRepository
    {
        Task AddAsync(TrainerProfile profile);
        Task<TrainerProfile?> GetByUserIdAsync(int userId);
        Task UpdateAsync(TrainerProfile profile);
        Task SaveChangesAsync();
    }
}
