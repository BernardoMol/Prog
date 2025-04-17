using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoTabelaMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", new string [] {"Nome"}, new object[] {"Rebolation"});
            migrationBuilder.InsertData("Musicas", new string [] {"Nome"}, new object[] {"In The End"});
            migrationBuilder.InsertData("Musicas", new string [] {"Nome"}, new object[] {"Jumento Celestino"});

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
