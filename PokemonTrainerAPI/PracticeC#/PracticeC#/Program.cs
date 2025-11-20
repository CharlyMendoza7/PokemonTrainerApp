using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PracticeC_.Repository;
using PracticeC_.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPokemonRepository, PokemonRepository>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
