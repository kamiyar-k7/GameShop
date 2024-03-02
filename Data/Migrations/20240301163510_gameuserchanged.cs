using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class gameuserchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Games",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserId",
                table: "Games",
                newName: "IX_Games_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UsersId",
                table: "Games",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UsersId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Games",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UsersId",
                table: "Games",
                newName: "IX_Games_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
