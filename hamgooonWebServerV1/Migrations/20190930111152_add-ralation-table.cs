using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hamgooonWebServerV1.Migrations
{
    public partial class addralationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Relation",
               columns: table => new
               {
                   Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),

                   FollowerId = table.Column<long>(nullable: false),
                   FollowedId = table.Column<long>(nullable: false),
                   EngagementRate = table.Column<int>(nullable: false),
                   MainCategory = table.Column<int>(nullable: false),
                   SubCategory = table.Column<int>(nullable: false),
                   LastSeenPostNumber = table.Column<int>(nullable: false),
                   TotalPostNumber = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Relation", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
