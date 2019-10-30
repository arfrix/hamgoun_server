using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class updateeventtableproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JudgeId",
                table: "Event",
                newName: "ActorId");

            migrationBuilder.AddColumn<long>(
                name: "ReactorId",
                table: "Event",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsComment",
                table: "Event",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommentReply",
                table: "Event",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactorId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IsComment",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IsCommentReply",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Event",
                newName: "JudgeId");
        }
    }
}
