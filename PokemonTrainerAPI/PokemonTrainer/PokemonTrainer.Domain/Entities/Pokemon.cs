

using System.ComponentModel.DataAnnotations;

namespace PokemonTrainer.Domain.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
