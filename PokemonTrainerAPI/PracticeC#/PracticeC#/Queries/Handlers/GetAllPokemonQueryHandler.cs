using MediatR;
using PracticeC_.Models;
using PracticeC_.Repository.Interfaces;

public class GetAllPokemonQueryHandler
    : IRequestHandler<GetAllPokemonQuery, List<Pokemon>>
{
    private readonly IPokemonRepository _pokemons;

    public GetAllPokemonQueryHandler(IPokemonRepository pokemons)
    {
        _pokemons = pokemons;
    }

    public Task<List<Pokemon>> Handle(GetAllPokemonQuery request, CancellationToken ct)
    {
        var pokemons = _pokemons.GetAllAsync();
        return pokemons;
    }
}
