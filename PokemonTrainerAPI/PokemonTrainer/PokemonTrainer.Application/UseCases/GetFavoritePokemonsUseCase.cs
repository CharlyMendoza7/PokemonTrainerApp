

using PokemonTrainer.Application.DTOs;
using PokemonTrainer.Domain.Entities;
using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Application.UseCases
{
    public class GetFavoritePokemonsUseCase
    {
        private readonly IFavoritePokemonRepository _favoritePokemonRepository;

        public GetFavoritePokemonsUseCase(IFavoritePokemonRepository favoritePokemonRepository)
        {
            _favoritePokemonRepository = favoritePokemonRepository;
        }

        public async Task<IEnumerable<FavoritePokemonDto>> ExecuteAsync(int profileId)
        {
            var favorites = await _favoritePokemonRepository.GetFavoritesAsync(profileId);

            var dtoList = favorites.Select(f => new FavoritePokemonDto
            {
                Id = f.Id,
                Name = f.Pokemon.Name,
                Type = f.Pokemon.Type,
            })
            .ToList();

            return dtoList;
         
        }
    }
}
