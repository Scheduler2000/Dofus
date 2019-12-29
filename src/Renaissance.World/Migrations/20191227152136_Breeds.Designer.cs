﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Breeds;

namespace Renaissance.World.Migrations
{
    [DbContext(typeof(BreedContext))]
    [Migration("20191227152136_Breeds")]
    partial class Breeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Breeds.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int[]>("BreedSpellsId")
                        .HasColumnType("integer[]");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("integer");

                    b.Property<int[]>("FemaleColors")
                        .HasColumnType("integer[]");

                    b.Property<string>("FemaleLook")
                        .HasColumnType("text");

                    b.Property<int>("GameplayClassDescriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("GameplayDescriptionId")
                        .HasColumnType("integer");

                    b.Property<int[]>("MaleColors")
                        .HasColumnType("integer[]");

                    b.Property<string>("MaleLook")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SpawnMap")
                        .HasColumnType("integer");

                    b.Property<string>("StatsPointsForAgilityCSV")
                        .HasColumnType("text");

                    b.Property<string>("StatsPointsForChanceCSV")
                        .HasColumnType("text");

                    b.Property<string>("StatsPointsForIntelligenceCSV")
                        .HasColumnType("text");

                    b.Property<string>("StatsPointsForStrengthCSV")
                        .HasColumnType("text");

                    b.Property<string>("StatsPointsForVitalityCSV")
                        .HasColumnType("text");

                    b.Property<string>("StatsPointsForWisdomCSV")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Breeds");
                });
#pragma warning restore 612, 618
        }
    }
}
