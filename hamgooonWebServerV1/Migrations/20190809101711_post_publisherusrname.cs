using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class post_publisherusrname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublisherUsername",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublisherUsername",
                table: "Post");
        }
    }
}
