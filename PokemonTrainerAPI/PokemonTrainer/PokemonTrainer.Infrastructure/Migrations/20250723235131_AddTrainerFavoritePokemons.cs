using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerFavoritePokemons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainerFavoritePokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerProfileId = table.Column<int>(type: "int", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerFavoritePokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerFavoritePokemons_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerFavoritePokemons_TrainerProfiles_TrainerProfileId",
                        column: x => x.TrainerProfileId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerFavoritePokemons_PokemonId",
                table: "TrainerFavoritePokemons",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerFavoritePokemons_TrainerProfileId",
                table: "TrainerFavoritePokemons",
                column: "TrainerProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerFavoritePokemons");
        }
    }
}
