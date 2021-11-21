using Microsoft.EntityFrameworkCore.Migrations;

namespace EHikeB.Data.Migrations
{
    public partial class adressaanpassing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndLocation",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StartLocation",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaiementMethod",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "zip",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AddressId",
                table: "Sessions",
                column: "AddressId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Locations_LocationId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AddressId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_LocationId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "PaiementMethod",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "EndLocation",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartLocation",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "zip",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
