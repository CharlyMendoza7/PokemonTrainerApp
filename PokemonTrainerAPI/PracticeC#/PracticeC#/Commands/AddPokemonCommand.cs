using MediatR;

public class AddPokemonCommand : IRequest<Unit>
{
    public string Name { get; set; }
}