﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Achievements;

namespace Renaissance.World.Migrations.Achievement
{
    [DbContext(typeof(AchievementContext))]
    [Migration("20191228175139_Achievements")]
    partial class Achievements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Achievements.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AccountLinked")
                        .HasColumnType("boolean");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("NameId")
                        .HasColumnType("text");

                    b.Property<List<int>>("ObjectiveIds")
                        .HasColumnType("integer[]");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<List<int>>("RewardIds")
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.ToTable("Achievements");
                });
#pragma warning restore 612, 618
        }
    }
}
