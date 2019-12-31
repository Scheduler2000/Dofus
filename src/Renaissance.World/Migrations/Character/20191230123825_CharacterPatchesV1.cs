using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Character
{
    public partial class CharacterPatchesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorLookBin",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "DefaultLookStr",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastLookStr",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultLookStr",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LastLookStr",
                table: "Characters");

            migrationBuilder.AddColumn<byte[]>(
                name: "ActorLookBin",
                table: "Characters",
                type: "bytea",
                nullable: true);
        }
    }
}
