
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Application.UseCases
{
    public class AddFavoritePokemonUseCase
    {
        public readonly IFavoritePokemonRepository _favoritePokemonRepository;

        public AddFavoritePokemonUseCase(IFavoritePokemonRepository favoritePokemonRepository)
        {
            _favoritePokemonRepository = favoritePokemonRepository;
        }

        public async Task<bool> ExecuteAsync(int userId, int pokemonId)
        {
            await _favoritePokemonRepository.AddFavoriteAsync(userId, pokemonId);
            await _favoritePokemonRepository.SaveChangesAsync();

            return true;
        }
    }
}
