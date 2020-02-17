using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veteries.DataAccess.Migrations
{
    public partial class AddVeterinarianAndAddressMigrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarian",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    OfficeName = table.Column<string>(maxLength: 20, nullable: false),
                    PaymentRange = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinarian_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarian_AddressId",
                table: "Veterinarian",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veterinarian");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
