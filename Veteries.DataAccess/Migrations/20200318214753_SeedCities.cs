using Microsoft.EntityFrameworkCore.Migrations;

namespace Veteries.DataAccess.Migrations
{
    public partial class SeedCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 2000, "Warszawa" },
                    { 2001, "Kraków" },
                    { 2002, "Lublin" },
                    { 2003, "Poznań" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "ID",
                keyValue: 2003);
        }
    }
}
