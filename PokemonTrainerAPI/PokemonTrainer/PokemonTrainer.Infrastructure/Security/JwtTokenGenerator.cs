

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PokemonTrainer.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonTrainer.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _config;

        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(int userId, string username, string? role)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:DurationMinutes"]!)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            Console.WriteLine($"Key: {_config["Jwt:Key"]}");
            Console.WriteLine($"Issuer: {_config["Jwt:Issuer"]}");
            Console.WriteLine($"Audience: {_config["Jwt:Audience"]}");
            Console.WriteLine($"Duration: {_config["Jwt:DurationMinutes"]}");

            return tokenHandler.WriteToken(token);
        }
    }
}
