using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class commetcompelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "Mizoun",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Namizoun",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublisherImg",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublisherUsername",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Comment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
