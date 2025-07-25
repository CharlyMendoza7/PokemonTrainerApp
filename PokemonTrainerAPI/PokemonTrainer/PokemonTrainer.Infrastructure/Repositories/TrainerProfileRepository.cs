

using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;
using PokemonTrainer.Infrastructure.Data;

namespace PokemonTrainer.Infrastructure.Repositories
{
    public class TrainerProfileRepository : ITrainerProfileRepository
    {
        private readonly PokemonTrainerDbContext _context;

        public TrainerProfileRepository(PokemonTrainerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TrainerProfile profile)
        {
            await _context.TrainerProfiles.AddAsync(profile);
        }

        public async Task<TrainerProfile?> GetByUserIdAsync(int userId)
        {
            return await _context.TrainerProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task UpdateAsync(TrainerProfile profile)
        {
            _context.TrainerProfiles.Update(profile);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
