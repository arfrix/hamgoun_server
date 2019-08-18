﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hamgooonWebServerV1.Data;

namespace hamgooonWebServerV1.Migrations
{
    [DbContext(typeof(HamgooonContext))]
    [Migration("20190801174327_Relation")]
    partial class Relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("hamgooonWebServerV1.Models.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("FirstTag");

                    b.Property<string>("FourthTag");

                    b.Property<int>("MainCategory");

                    b.Property<int>("Number");

                    b.Property<string>("PostSummary");

                    b.Property<long>("PublisherId");

                    b.Property<string>("SecondTag");

                    b.Property<int>("SubCategory");

                    b.Property<string>("ThirdTag");

                    b.Property<string>("Title");

                    b.Property<string>("UniqueUrl");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("hamgooonWebServerV1.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int>("EmailCode");

                    b.Property<bool>("EmailVerifed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Pass");

                    b.Property<long>("PhoneNumber");

                    b.Property<bool>("PhoneVerifed");

                    b.Property<string>("ProfileImgUrl");

                    b.Property<int>("SMSCode");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
