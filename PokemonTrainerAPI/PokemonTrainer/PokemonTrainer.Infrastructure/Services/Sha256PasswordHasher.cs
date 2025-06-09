using PokemonTrainer.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PokemonTrainer.Infrastructure.Services
{
    public class Sha256PasswordHasher : IPasswordHasher
    {
        public string Hash(string rawPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Convert to hex string
            }
        }
    }
}
