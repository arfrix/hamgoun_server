using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class ratingevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JudgeId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable:true ),
                    CommentId = table.Column<long>(nullable: true),
                    IsMizoun = table.Column<bool>(nullable: true),
                    IsNamizoun = table.Column<bool>(nullable: true),
                    IsPostRating = table.Column<bool>(nullable: true),
                    PostRate = table.Column<int>(nullable: true),
                    


                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingEvent");
        }
    }
}
