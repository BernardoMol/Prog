using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Shared.Dados.Migrations
{
    /// <inheritdoc />
    public partial class POPULANDO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Populando Generos
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nome", "Descricao" },
                values: new object[,]
                {
                    { 1, "Rock", "Guitarras e atitude" },
                    { 2, "Jazz", "Improvisação e classe" },
                    { 3, "Pop", "Hits e mais hits" }
                });

            // Populando Artistas
            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Nome", "FotoPerfil", "Bio" },
                values: new object[,]
                {
                    { 1, "Queen", "queen.jpg", "Banda britânica de rock formada em 1970" },
                    { 2, "Miles Davis", "miles.jpg", "Lendário trompetista de jazz" }
                });

            // Populando Músicas
            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Nome", "AnoLancamento", "ArtistaId" },
                values: new object[,]
                {
                    { 1, "Bohemian Rhapsody", 1975, 1 },
                    { 2, "So What", 1959, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Musicas", "Id", 1);
            migrationBuilder.DeleteData("Musicas", "Id", 2);
            migrationBuilder.DeleteData("Artistas", "Id", 1);
            migrationBuilder.DeleteData("Artistas", "Id", 2);
            migrationBuilder.DeleteData("Generos", "Id", 1);
            migrationBuilder.DeleteData("Generos", "Id", 2);
            migrationBuilder.DeleteData("Generos", "Id", 3);
        }
    }
}
