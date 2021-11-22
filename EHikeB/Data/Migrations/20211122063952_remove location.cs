using Microsoft.EntityFrameworkCore.Migrations;

namespace EHikeB.Data.Migrations
{
    public partial class removelocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Locations_LocationId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cars_CarID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_LocationId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Sessions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Sessions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cars_CarID",
                table: "Sessions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cars_CarID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocationId",
                table: "Addresses",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Locations_LocationId",
                table: "Addresses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cars_CarID",
                table: "Sessions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
