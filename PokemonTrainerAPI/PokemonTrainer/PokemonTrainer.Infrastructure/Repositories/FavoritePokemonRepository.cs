

using Microsoft.EntityFrameworkCore;
using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;
using PokemonTrainer.Infrastructure.Data;

namespace PokemonTrainer.Infrastructure.Repositories
{
    public class FavoritePokemonRepository : IFavoritePokemonRepository
    {
        private readonly PokemonTrainerDbContext _context;

        public FavoritePokemonRepository(PokemonTrainerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainerFavoritePokemon>> GetFavoritesAsync(int profileId)
        {
            return await _context.TrainerFavoritePokemons
                .Where(x => x.TrainerProfileId == profileId)
                .ToListAsync();
        }

        public async Task AddFavoriteAsync(int profileId, int pokemonId)
        {
            var favorite = new TrainerFavoritePokemon
            {
                TrainerProfileId = profileId,
                PokemonId = pokemonId
            };

            await _context.TrainerFavoritePokemons.AddAsync(favorite);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
