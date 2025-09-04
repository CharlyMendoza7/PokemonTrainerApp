import { mockPokemonList } from "./mockdata"
import { PokemonCard } from "./PokemonCard"


export const PokedexPage = () => {
    return (
        <div>
            <h2>Pokedex</h2>
            <div>
                {mockPokemonList.map(pokemon => (
                    <PokemonCard key={pokemon.id} pokemon={pokemon} />
                ))}
            </div>
        </div>
    )
}
