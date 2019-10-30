using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class addpostTypetopost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Post");
        }
    }
}
