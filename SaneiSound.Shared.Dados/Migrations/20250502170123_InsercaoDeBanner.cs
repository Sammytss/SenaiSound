using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaneiSound.Shared.Dados.Migrations
{
    /// <inheritdoc />
    public partial class InsercaoDeBanner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroMusica");

            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "Artistas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Artistas");

            migrationBuilder.CreateTable(
                name: "GeneroMusica",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    MusicasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusica", x => new { x.GenerosId, x.MusicasId });
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Musicas_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroMusica_MusicasId",
                table: "GeneroMusica",
                column: "MusicasId");
        }
    }
}
