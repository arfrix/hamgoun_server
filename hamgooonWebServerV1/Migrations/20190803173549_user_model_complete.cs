using Microsoft.EntityFrameworkCore.Migrations;

namespace hamgooonWebServerV1.Migrations
{
    public partial class user_model_complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_category1Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Book_category2Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edu_highSchool",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edu_subject",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edu_univercity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languge_dialect",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languge_forthLangName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languge_motherTongue",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languge_secondLangName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languge_thirdLangName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_livingCountry",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_livingTown",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_motherTown",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie_category1Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Movie_category2Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Music_category1Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Music_category2Name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Relation",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill_mainSkillName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skill_secondSkillName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sport_name",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sport_playerName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sport_teamName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StickerUrl1",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StickerUrl2",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StickerUrl3",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StickerUrl4",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StickerUrl5",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teach_mainTeachName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teach_secondTeachName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Work_company",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Work_job",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_category1Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Book_category2Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Edu_highSchool",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Edu_subject",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Edu_univercity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languge_dialect",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languge_forthLangName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languge_motherTongue",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languge_secondLangName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Languge_thirdLangName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Location_livingCountry",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Location_livingTown",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Location_motherTown",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Movie_category1Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Movie_category2Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Music_category1Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Music_category2Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Skill_mainSkillName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Skill_secondSkillName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Sport_name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Sport_playerName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Sport_teamName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StickerUrl1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StickerUrl2",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StickerUrl3",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StickerUrl4",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StickerUrl5",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Teach_mainTeachName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Teach_secondTeachName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Work_company",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Work_job",
                table: "User");
        }
    }
}
