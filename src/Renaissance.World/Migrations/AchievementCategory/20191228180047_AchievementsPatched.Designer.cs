﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Achievements.Categories;

namespace Renaissance.World.Migrations.AchievementCategory
{
    [DbContext(typeof(AchievementCategoryContext))]
    [Migration("20191228180047_AchievementsPatched")]
    partial class AchievementsPatched
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Achievements.Categories.AchievementCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<List<int>>("AchievementIds")
                        .HasColumnType("integer[]");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("VisibilityCriterion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AchievementsCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
