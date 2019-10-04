﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hamgooonWebServerV1.Data;

namespace hamgooonWebServerV1.Migrations
{
    [DbContext(typeof(HamgooonContext))]
    partial class HamgooonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("hamgooonWebServerV1.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText");

                    b.Property<bool>("IsReply");

                    b.Property<int>("Mizoun");

                    b.Property<int>("Namizoun");

                    b.Property<long>("ParentCommentId");

                    b.Property<long>("PostId");

                    b.Property<long>("PublisherId");

                    b.Property<string>("PublisherImg");

                    b.Property<string>("PublisherUsername");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PublisherId");

                    b.Property<string>("url");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<int>("CommentCount");

                    b.Property<string>("FirstTag");

                    b.Property<string>("FourthTag");

                    b.Property<bool>("IsDrafted");

                    b.Property<int>("JudgesCount");

                    b.Property<int>("Kind");

                    b.Property<int>("MainCategory");

                    b.Property<int>("Number");

                    b.Property<double>("PostRate");

                    b.Property<string>("PostSummary");

                    b.Property<long>("PublisherId");

                    b.Property<string>("PublisherProfileImg");

                    b.Property<string>("PublisherUsername");

                    b.Property<string>("SecondTag");

                    b.Property<int>("SubCategory");

                    b.Property<string>("ThirdTag");

                    b.Property<string>("Title");

                    b.Property<string>("UniqueUrl");

                    b.Property<string>("coverImgUrl");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.RatingEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CommentId");

                    b.Property<bool>("IsMizoun");

                    b.Property<bool>("IsNamizoun");

                    b.Property<bool>("IsPostRating");

                    b.Property<long>("JudgeId");

                    b.Property<long>("PostId");

                    b.Property<int>("PostRate");

                    b.HasKey("Id");

                    b.ToTable("RatingEvent");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.Relation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EngagementRate");

                    b.Property<long>("FollowedId");

                    b.Property<long>("FollowerId");

                    b.Property<int>("LastSeenPostNumber");

                    b.Property<int>("MainCategory");

                    b.Property<int>("SubCategory");

                    b.Property<int>("TotalPostNumber");

                    b.HasKey("Id");

                    b.ToTable("Relation");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Book_category1Name");

                    b.Property<string>("Book_category2Name");

                    b.Property<string>("Edu_highSchool");

                    b.Property<string>("Edu_subject");

                    b.Property<string>("Edu_univercity");

                    b.Property<string>("Email");

                    b.Property<int>("EmailCode");

                    b.Property<bool>("EmailVerifed");

                    b.Property<string>("Firstname");

                    b.Property<long>("Hamegyry");

                    b.Property<long>("Hamrahy");

                    b.Property<string>("Languge_dialect");

                    b.Property<string>("Languge_forthLangName");

                    b.Property<string>("Languge_motherTongue");

                    b.Property<string>("Languge_secondLangName");

                    b.Property<string>("Languge_thirdLangName");

                    b.Property<string>("Lastname");

                    b.Property<string>("Location_livingCountry");

                    b.Property<string>("Location_livingTown");

                    b.Property<string>("Location_motherTown");

                    b.Property<string>("Movie_category1Name");

                    b.Property<string>("Movie_category2Name");

                    b.Property<string>("Music_category1Name");

                    b.Property<string>("Music_category2Name");

                    b.Property<string>("Pass");

                    b.Property<long>("PhoneNumber");

                    b.Property<bool>("PhoneVerifed");

                    b.Property<string>("ProfileImgUrl");

                    b.Property<string>("Relation");

                    b.Property<int>("SMSCode");

                    b.Property<string>("Skill_mainSkillName");

                    b.Property<string>("Skill_secondSkillName");

                    b.Property<string>("Sport_name");

                    b.Property<string>("Sport_playerName");

                    b.Property<string>("Sport_teamName");

                    b.Property<string>("StickerUrl1");

                    b.Property<string>("StickerUrl2");

                    b.Property<string>("StickerUrl3");

                    b.Property<string>("StickerUrl4");

                    b.Property<string>("StickerUrl5");

                    b.Property<string>("Teach_mainTeachName");

                    b.Property<string>("Teach_secondTeachName");

                    b.Property<string>("UserName");

                    b.Property<string>("Work_company");

                    b.Property<string>("Work_job");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
