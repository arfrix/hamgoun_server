using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class Comment_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PublisherId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    IsReply = table.Column<bool>(nullable: true),
                    ParentCommentId = table.Column<long>(nullable: true),
                    CommentText = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
