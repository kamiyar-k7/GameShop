using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Locations_LocationId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_LocationId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "PosstCode",
                table: "Locations",
                newName: "PostCode");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNote",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CartId",
                table: "Locations",
                column: "CartId",
                unique: true,
                filter: "[CartId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cart_CartId",
                table: "Locations",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cart_CartId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CartId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Locations",
                newName: "PosstCode");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNote",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_LocationId",
                table: "Cart",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Locations_LocationId",
                table: "Cart",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
