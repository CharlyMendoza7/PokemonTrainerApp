

using PokemonTrainer.Domain.Interfaces;

namespace PokemonTrainer.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public DateTime? Birth {  get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Permission { get; set; } = "user";

        public void SetPassword(string rawPassword, IPasswordHasher hasher)
        {
            PasswordHash = hasher.Hash(rawPassword);
        }

        public bool IsPasswordValid(string rawPassword, IPasswordHasher hasher){
        {
                return PasswordHash == hasher.Hash(rawPassword);    
        }
    }
}
