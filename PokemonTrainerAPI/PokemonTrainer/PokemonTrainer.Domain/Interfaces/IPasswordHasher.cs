﻿namespace PokemonTrainer.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string rawPassword);
    }
}
