using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Character
{
    public partial class Characters3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Look",
                table: "Characters");

            migrationBuilder.AddColumn<byte[]>(
                name: "ActorLookBin",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Level",
                table: "Characters",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorLookBin",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Look",
                table: "Characters",
                type: "text",
                nullable: true);
        }
    }
}
