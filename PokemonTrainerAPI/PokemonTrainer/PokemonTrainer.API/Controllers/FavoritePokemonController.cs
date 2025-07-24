using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PokemonTrainer.Application.UseCases;

namespace PokemonTrainer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    [Authorize]
    public class FavoritePokemonController : ControllerBase
    {
        private readonly AddFavoritePokemonUseCase _addFavoritePokemonUseCase;
        private readonly GetFavoritePokemonsUseCase _getFavoritePokemonsUseCase;

        public FavoritePokemonController(AddFavoritePokemonUseCase addFavoritePokemonUseCase, GetFavoritePokemonsUseCase getFavoritePokemonsUseCase)
        {
            _addFavoritePokemonUseCase = addFavoritePokemonUseCase;
            _getFavoritePokemonsUseCase = getFavoritePokemonsUseCase;
        }

        [HttpGet("getFavorites/{profileId}")]
        public async Task<IActionResult> GetFavorites(int profileId)
        {
            var favPokemons = await _getFavoritePokemonsUseCase.ExecuteAsync(profileId);

            return Ok(favPokemons);
        }

        [HttpPost("addFavorites/{profileId}")]
        public async Task<IActionResult> AddFavorite(int profileId,[FromBody] int pokemonId)
        {
            var result = await _addFavoritePokemonUseCase.ExecuteAsync(profileId, pokemonId);

            return result ? Ok() : BadRequest("Failed to add favorite.");
        }
    }
}
