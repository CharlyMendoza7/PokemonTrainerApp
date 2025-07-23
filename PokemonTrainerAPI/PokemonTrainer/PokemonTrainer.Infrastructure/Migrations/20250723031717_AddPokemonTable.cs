using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerProfiles_FavoritePokemonId",
                table: "TrainerProfiles",
                column: "FavoritePokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerProfiles_Pokemons_FavoritePokemonId",
                table: "TrainerProfiles",
                column: "FavoritePokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerProfiles_Pokemons_FavoritePokemonId",
                table: "TrainerProfiles");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_TrainerProfiles_FavoritePokemonId",
                table: "TrainerProfiles");
        }
    }
}
