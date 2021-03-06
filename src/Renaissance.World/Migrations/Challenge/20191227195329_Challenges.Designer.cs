﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Challenges;

namespace Renaissance.World.Migrations.Challenge
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20191227195329_Challenges")]
    partial class Challenges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Challenges.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("DareAvailable")
                        .HasColumnType("boolean");

                    b.Property<long>("DescriptionId")
                        .HasColumnType("bigint");

                    b.Property<List<uint>>("IncompatibleChallenges")
                        .HasColumnType("bigint[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
