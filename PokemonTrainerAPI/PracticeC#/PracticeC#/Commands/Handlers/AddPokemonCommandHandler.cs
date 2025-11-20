using MediatR;
using PracticeC_.Models;
using PracticeC_.Repository.Interfaces;

public class AddPokemonCommandHandler
    : IRequestHandler<AddPokemonCommand, Unit>
{
    private readonly IPokemonRepository _pokemons;

    public AddPokemonCommandHandler(IPokemonRepository pokemons)
    {
        _pokemons = pokemons;
    }

    public async Task<Unit> Handle(AddPokemonCommand request, CancellationToken ct)
    {
        await _pokemons.AddAsync(new Pokemon { Name = request.Name });
        return Unit.Value;
    }
}
