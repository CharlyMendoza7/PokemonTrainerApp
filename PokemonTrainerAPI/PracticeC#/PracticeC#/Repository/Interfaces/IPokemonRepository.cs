using PracticeC_.Models;

namespace PracticeC_.Repository.Interfaces
{
    public interface IPokemonRepository
    {
        public Task<Pokemon> AddAsync(Pokemon pokemon);
        public Task<List<Pokemon>> GetAllAsync();
        public Task<Pokemon> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id); 
    }
}
