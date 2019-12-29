using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Monster
{
    public partial class MonstersPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PercentDropForGrade1",
                table: "MonstersDrops",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentDropForGrade2",
                table: "MonstersDrops",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentDropForGrade3",
                table: "MonstersDrops",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentDropForGrade4",
                table: "MonstersDrops",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentDropForGrade5",
                table: "MonstersDrops",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentDropForGrade1",
                table: "MonstersDrops");

            migrationBuilder.DropColumn(
                name: "PercentDropForGrade2",
                table: "MonstersDrops");

            migrationBuilder.DropColumn(
                name: "PercentDropForGrade3",
                table: "MonstersDrops");

            migrationBuilder.DropColumn(
                name: "PercentDropForGrade4",
                table: "MonstersDrops");

            migrationBuilder.DropColumn(
                name: "PercentDropForGrade5",
                table: "MonstersDrops");
        }
    }
}
