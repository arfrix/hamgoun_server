using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class Post_kind_and_IsDrafted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDrafted",
                table: "Post",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "Kind",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "IsDrafted",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "Post");
        }
    }
}
