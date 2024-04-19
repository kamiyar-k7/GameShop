using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class screenfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenshot_Games_GameId",
                table: "Screenshot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screenshot",
                table: "Screenshot");

            migrationBuilder.RenameTable(
                name: "Screenshot",
                newName: "Screenshots");

            migrationBuilder.RenameIndex(
                name: "IX_Screenshot_GameId",
                table: "Screenshots",
                newName: "IX_Screenshots_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantitiy",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screenshots",
                table: "Screenshots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshots_Games_GameId",
                table: "Screenshots",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenshots_Games_GameId",
                table: "Screenshots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screenshots",
                table: "Screenshots");

            migrationBuilder.RenameTable(
                name: "Screenshots",
                newName: "Screenshot");

            migrationBuilder.RenameIndex(
                name: "IX_Screenshots_GameId",
                table: "Screenshot",
                newName: "IX_Screenshot_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantitiy",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screenshot",
                table: "Screenshot",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshot_Games_GameId",
                table: "Screenshot",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
