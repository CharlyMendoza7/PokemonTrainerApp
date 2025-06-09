
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore
using PokemonTrainer.Application.UseCases;
using PokemonTrainer.Domain.Interfaces;
using PokemonTrainer.Infrastructure.Data;
using PokemonTrainer.Infrastructure.Repositories;
using PokemonTrainer.Infrastructure.Services;

namespace PokemonTrainer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PokemonTrainerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher, Sha256PasswordHasher>();
            builder.Services.AddScoped<RegisterUserUseCase>();
            builder.Services.AddScoped<AuthenticateUserUseCase>();
            builder.Services.AddScoped<GetAllUsersUseCase>();

            //add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            //use CORS middleware
            app.UseCors("AllowSpecificOrigins");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
