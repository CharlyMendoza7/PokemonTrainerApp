

using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonTrainer.Domain.Entities
{
    public class TrainerFavoritePokemon
    {
        public int Id { get; set; }
        [ForeignKey(nameof(TrainerProfile))]
        public int TrainerProfileId { get; set; }
        [ForeignKey(nameof(Pokemon))]
        public int PokemonId { get; set; }

        public TrainerProfile TrainerProfile { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
