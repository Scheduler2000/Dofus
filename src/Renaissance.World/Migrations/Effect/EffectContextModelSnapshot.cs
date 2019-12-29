﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Effects;

namespace Renaissance.World.Migrations.Effect
{
    [DbContext(typeof(EffectContext))]
    partial class EffectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Effects.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("BonusType")
                        .HasColumnType("integer");

                    b.Property<bool>("Boost")
                        .HasColumnType("boolean");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int>("Characteristic")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EffectPriority")
                        .HasColumnType("integer");

                    b.Property<int>("ElementId")
                        .HasColumnType("integer");

                    b.Property<bool>("ForceMinMax")
                        .HasColumnType("boolean");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<string>("Operator")
                        .HasColumnType("text");

                    b.Property<int>("OppositeId")
                        .HasColumnType("integer");

                    b.Property<bool>("ShowInSet")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowInTooltip")
                        .HasColumnType("boolean");

                    b.Property<int>("TheoreticalDescriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("TheoreticalPattern")
                        .HasColumnType("integer");

                    b.Property<bool>("UseDice")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseInFight")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Effects");
                });
#pragma warning restore 612, 618
        }
    }
}