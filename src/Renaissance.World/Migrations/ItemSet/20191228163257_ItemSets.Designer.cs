﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Renaissance.World.Database.Items.Panoplies;

namespace Renaissance.World.Migrations.ItemSet
{
    [DbContext(typeof(ItemSetContext))]
    [Migration("20191228163257_ItemSets")]
    partial class ItemSets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Renaissance.World.Database.Items.Panoplies.ItemSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("BonusIsSecret")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("EffectsBin")
                        .HasColumnType("bytea");

                    b.Property<List<int>>("Items")
                        .HasColumnType("integer[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ItemsSets");
                });
#pragma warning restore 612, 618
        }
    }
}
