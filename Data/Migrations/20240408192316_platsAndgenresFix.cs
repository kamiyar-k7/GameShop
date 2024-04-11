using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class platsAndgenresFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformUniqueName",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "GenreUniqueName",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "GameStatus",
                table: "Games",
                newName: "GamesStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GamesStatus",
                table: "Games",
                newName: "GameStatus");

            migrationBuilder.AddColumn<string>(
                name: "PlatformUniqueName",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GenreUniqueName",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
