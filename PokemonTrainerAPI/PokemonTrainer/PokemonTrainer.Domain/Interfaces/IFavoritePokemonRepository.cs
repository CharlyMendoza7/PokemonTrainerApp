

using PokemonTrainer.Domain.Entities;

namespace PokemonTrainer.Domain.Interfaces
{
    public interface IFavoritePokemonRepository
    {
        Task<IEnumerable<TrainerFavoritePokemon>> GetFavoritesAsync(int userId);
        Task AddFavoriteAsync(int profileId,int pokemonId);
        Task SaveChangesAsync();

    }
}
