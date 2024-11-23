using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Models;

namespace PokemonTrainer.Data
{
    public class PokemonTrainerDbContext : DbContext
    {
        public PokemonTrainerDbContext(DbContextOptions<PokemonTrainerDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
