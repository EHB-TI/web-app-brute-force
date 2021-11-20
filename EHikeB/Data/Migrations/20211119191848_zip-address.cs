using Microsoft.EntityFrameworkCore.Migrations;

namespace EHikeB.Data.Migrations
{
    public partial class zipaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_CustomerId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Cars",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                newName: "IX_Cars_CustomerID");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(nullable: false),
                    StreetNumber = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zip = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    lng = table.Column<float>(nullable: false),
                    lat = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_CustomerID",
                table: "Cars",
                column: "CustomerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_CustomerID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Cars",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CustomerID",
                table: "Cars",
                newName: "IX_Cars_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
