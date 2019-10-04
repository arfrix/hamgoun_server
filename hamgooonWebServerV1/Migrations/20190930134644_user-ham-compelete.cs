using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class userhamcompelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Hamegyry",
                table: "User",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Hamrahy",
                table: "User",
                nullable: true,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hamegyry",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Hamrahy",
                table: "User");
        }
    }
}
