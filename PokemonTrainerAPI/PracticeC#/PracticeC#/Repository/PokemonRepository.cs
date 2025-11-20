using Microsoft.AspNetCore.Http.HttpResults;
using PracticeC_.Models;
using PracticeC_.Repository.Interfaces;

namespace PracticeC_.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private static readonly List<Pokemon> _pokemons = new();

        public Task<Pokemon> AddAsync(Pokemon pokemon)
        {
            pokemon.Id = _pokemons.Count == 0 ? 1 : _pokemons.Max(p => p.Id) + 1;
            _pokemons.Add(pokemon);

            return Task.FromResult(pokemon);
        }

        public Task<List<Pokemon>> GetAllAsync()
        {
            return Task.FromResult(_pokemons);
        }
        public Task<Pokemon> GetByIdAsync(int id)
        {
            var p = _pokemons.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(p);
        }
        public Task<bool> DeleteAsync(int id)
        {
            var p = GetByIdAsync(id).Result;

            _pokemons.Remove(p);

            return Task.FromResult(true);
        }
    }
}
