using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixcartname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartUser_Carts_UserCartId",
                table: "CartUser");

            migrationBuilder.RenameColumn(
                name: "UserCartId",
                table: "CartUser",
                newName: "CartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartUser_Carts_CartsId",
                table: "CartUser",
                column: "CartsId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartUser_Carts_CartsId",
                table: "CartUser");

            migrationBuilder.RenameColumn(
                name: "CartsId",
                table: "CartUser",
                newName: "UserCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartUser_Carts_UserCartId",
                table: "CartUser",
                column: "UserCartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
