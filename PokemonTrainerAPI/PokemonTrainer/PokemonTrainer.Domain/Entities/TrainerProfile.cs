

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonTrainer.Domain.Entities
{
    public class TrainerProfile
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Region { get; set; }
        public string? AvatarUrl { get; set; }
        [ForeignKey(nameof(FavoritePokemon))]
        public int? FavoritePokemonId { get; set; }
        public string? BadgesJson { get; set; } //todo implementation later list
        public int? BattlesWon { get; set; }
        public int? BattlesLost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive {  get; set; }

        public User User { get; set; }
        public Pokemon? FavoritePokemon { get; set; }

        public TrainerProfile()
        {
            CreatedAt = DateTime.UtcNow;
            LastActive = DateTime.UtcNow;
        }
    }
}
