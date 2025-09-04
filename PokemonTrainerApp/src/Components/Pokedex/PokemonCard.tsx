
type Pokemon = {
    id: number;
    name: string;
    image: string;
}

export const PokemonCard = ({ pokemon }: { pokemon: Pokemon }) => {

    const handleAddFavorite = () => {
        alert(`${pokemon.name} added to favorites!`);

        //TODO: CALL BACKEND ENDPOINT
    }

    return (
        <div>
            <img src={pokemon.image} alt={pokemon.name} />
            <h4>{pokemon.name}</h4>
            <button onClick={handleAddFavorite}>Add to Favorites</button>
        </div>
    )
}
