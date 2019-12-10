using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamgoonAPI.Migrations.MySQL
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublisherId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    IsReply = table.Column<bool>(nullable: false),
                    ParentCommentId = table.Column<long>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    Mizoun = table.Column<int>(nullable: false),
                    Namizoun = table.Column<int>(nullable: false),
                    PublisherImg = table.Column<string>(nullable: true),
                    PublisherUsername = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActorId = table.Column<long>(nullable: false),
                    ActorUsername = table.Column<string>(nullable: true),
                    ActorImgUrl = table.Column<string>(nullable: true),
                    ReactorId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false),
                    CommentId = table.Column<long>(nullable: false),
                    IsComment = table.Column<bool>(nullable: false),
                    IsCommentReply = table.Column<bool>(nullable: false),
                    IsMizoun = table.Column<bool>(nullable: false),
                    IsNamizoun = table.Column<bool>(nullable: false),
                    IsPostRating = table.Column<bool>(nullable: false),
                    PostRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublisherId = table.Column<long>(nullable: false),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UniqueUrl = table.Column<string>(nullable: true),
                    PublisherId = table.Column<long>(nullable: false),
                    PublisherProfileImg = table.Column<string>(nullable: true),
                    PublisherUsername = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    PostSummary = table.Column<string>(nullable: true),
                    PostType = table.Column<string>(nullable: true),
                    FirstTag = table.Column<string>(nullable: true),
                    SecondTag = table.Column<string>(nullable: true),
                    ThirdTag = table.Column<string>(nullable: true),
                    FourthTag = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    MainCategory = table.Column<int>(nullable: false),
                    SubCategory = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    IsDrafted = table.Column<bool>(nullable: false),
                    coverImgUrl = table.Column<string>(nullable: true),
                    CommentCount = table.Column<int>(nullable: false),
                    JudgesCount = table.Column<int>(nullable: false),
                    PostRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ProfileImgUrl = table.Column<string>(nullable: true),
                    Hamegyry = table.Column<long>(nullable: false),
                    Hamrahy = table.Column<long>(nullable: false),
                    PhoneVerifed = table.Column<bool>(nullable: false),
                    SMSCode = table.Column<int>(nullable: false),
                    EmailVerifed = table.Column<bool>(nullable: false),
                    EmailCode = table.Column<int>(nullable: false),
                    StickerUrl1 = table.Column<string>(nullable: true),
                    StickerUrl2 = table.Column<string>(nullable: true),
                    StickerUrl3 = table.Column<string>(nullable: true),
                    StickerUrl4 = table.Column<string>(nullable: true),
                    StickerUrl5 = table.Column<string>(nullable: true),
                    Edu_highSchool = table.Column<string>(nullable: true),
                    Edu_univercity = table.Column<string>(nullable: true),
                    Edu_subject = table.Column<string>(nullable: true),
                    Work_job = table.Column<string>(nullable: true),
                    Work_company = table.Column<string>(nullable: true),
                    Location_motherTown = table.Column<string>(nullable: true),
                    Location_livingCountry = table.Column<string>(nullable: true),
                    Location_livingTown = table.Column<string>(nullable: true),
                    Languge_motherTongue = table.Column<string>(nullable: true),
                    Languge_dialect = table.Column<string>(nullable: true),
                    Languge_secondLangName = table.Column<string>(nullable: true),
                    Languge_thirdLangName = table.Column<string>(nullable: true),
                    Languge_forthLangName = table.Column<string>(nullable: true),
                    Relation = table.Column<string>(nullable: true),
                    Sport_name = table.Column<string>(nullable: true),
                    Sport_teamName = table.Column<string>(nullable: true),
                    Sport_playerName = table.Column<string>(nullable: true),
                    Movie_category1Name = table.Column<string>(nullable: true),
                    Movie_category2Name = table.Column<string>(nullable: true),
                    Book_category1Name = table.Column<string>(nullable: true),
                    Book_category2Name = table.Column<string>(nullable: true),
                    Music_category1Name = table.Column<string>(nullable: true),
                    Music_category2Name = table.Column<string>(nullable: true),
                    Skill_mainSkillName = table.Column<string>(nullable: true),
                    Skill_secondSkillName = table.Column<string>(nullable: true),
                    Teach_mainTeachName = table.Column<string>(nullable: true),
                    Teach_secondTeachName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
