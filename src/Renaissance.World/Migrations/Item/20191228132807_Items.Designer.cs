﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Items;

namespace Renaissance.World.Migrations.Item
{
    [DbContext(typeof(ItemContext))]
    [Migration("20191228132807_Items")]
    partial class Items
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Items.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AppearanceId")
                        .HasColumnType("integer");

                    b.Property<bool>("BonusIsSecret")
                        .HasColumnType("boolean");

                    b.Property<string>("CraftFeasible")
                        .HasColumnType("text");

                    b.Property<string>("CraftVisible")
                        .HasColumnType("text");

                    b.Property<int>("CraftXpRatio")
                        .HasColumnType("integer");

                    b.Property<string>("Criteria")
                        .HasColumnType("text");

                    b.Property<string>("CriteriaTarget")
                        .HasColumnType("text");

                    b.Property<bool>("Cursed")
                        .HasColumnType("boolean");

                    b.Property<int>("DescriptionId")
                        .HasColumnType("integer");

                    b.Property<List<int>>("DropMonsterIds")
                        .HasColumnType("integer[]");

                    b.Property<bool>("Enhanceable")
                        .HasColumnType("boolean");

                    b.Property<bool>("Etheral")
                        .HasColumnType("boolean");

                    b.Property<List<int>>("EvolutiveEffectIds")
                        .HasColumnType("integer[]");

                    b.Property<bool>("Exchangeable")
                        .HasColumnType("boolean");

                    b.Property<List<int>>("FavoriteSubAreas")
                        .HasColumnType("integer[]");

                    b.Property<int>("FavoriteSubAreasBonus")
                        .HasColumnType("integer");

                    b.Property<bool>("HideEffects")
                        .HasColumnType("boolean");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDestructible")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSaleable")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemSetId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("NeedUseConfirm")
                        .HasColumnType("boolean");

                    b.Property<bool>("NonUsableOnAnother")
                        .HasColumnType("boolean");

                    b.Property<string>("NuggetsBySubareaCSV")
                        .HasColumnType("text");

                    b.Property<byte[]>("PossibleEffectsBin")
                        .HasColumnType("bytea");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("RealWeight")
                        .HasColumnType("integer");

                    b.Property<List<int>>("RecipeIds")
                        .HasColumnType("integer[]");

                    b.Property<int>("RecipeSlots")
                        .HasColumnType("integer");

                    b.Property<string>("ResourcesBySubareaCSV")
                        .HasColumnType("text");

                    b.Property<bool>("SecretRecipe")
                        .HasColumnType("boolean");

                    b.Property<bool>("Targetable")
                        .HasColumnType("boolean");

                    b.Property<bool>("TwoHanded")
                        .HasColumnType("boolean");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("Usable")
                        .HasColumnType("boolean");

                    b.Property<int>("UseAnimationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
