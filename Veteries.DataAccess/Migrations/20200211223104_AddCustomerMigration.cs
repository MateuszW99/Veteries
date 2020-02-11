using Microsoft.EntityFrameworkCore.Migrations;

namespace Veteries.DataAccess.Migrations
{
    public partial class AddCustomerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Patient",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_OwnerId",
                table: "Patient",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Person_OwnerId",
                table: "Patient",
                column: "OwnerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Person_OwnerId",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Patient_OwnerId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Patient");
        }
    }
}
