using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class addcommenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublisherId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    IsReply = table.Column<bool>(nullable: true),
                    ParentCommentId = table.Column<long>(nullable: true),
                    CommentText = table.Column<string>(nullable: false),
                    
                    Mizoun = table.Column<int>(nullable: true ),
                    Namizoun = table.Column<int>(nullable:true ),
                    PublisherImg = table.Column<string>(nullable: true),
                    PublisherUsername = table.Column<string>(nullable:false ),
                    Score = table.Column<int>(nullable:true ),

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
