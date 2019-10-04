using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class drophamsserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hamegyry",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Hamrahy",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
