using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class addactorUsernameandactorImgurlevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActorImgUrl",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActorUsername",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorImgUrl",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ActorUsername",
                table: "Event");
        }
    }
}
