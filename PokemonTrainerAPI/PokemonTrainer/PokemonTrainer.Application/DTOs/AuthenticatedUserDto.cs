

namespace PokemonTrainer.Application.DTOs
{
    public class AuthenticatedUserDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string? Role { get; set; }
    }
}
