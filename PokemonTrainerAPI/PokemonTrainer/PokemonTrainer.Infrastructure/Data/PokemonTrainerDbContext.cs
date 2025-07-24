using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Domain.Entities;

namespace PokemonTrainer.Infrastructure.Data
{
    public class PokemonTrainerDbContext : DbContext
    {
        public PokemonTrainerDbContext(DbContextOptions<PokemonTrainerDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies(false); // Disable lazy loading.
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<TrainerProfile> TrainerProfiles { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<TrainerFavoritePokemon> TrainerFavoritePokemons { get; set; }
    }
}
