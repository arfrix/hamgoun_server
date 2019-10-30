using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class changeratingEventtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RatingEvent",
                newName: "Event");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
