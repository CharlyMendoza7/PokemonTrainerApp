namespace PokemonTrainer.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime Birth {  get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
