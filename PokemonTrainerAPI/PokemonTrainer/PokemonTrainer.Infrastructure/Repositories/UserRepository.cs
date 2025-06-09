using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Infrastructure.Data;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PokemonTrainerDbContext _context;

        public UserRepository(PokemonTrainerDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
