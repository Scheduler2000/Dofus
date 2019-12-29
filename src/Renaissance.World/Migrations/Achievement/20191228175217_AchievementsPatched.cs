using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Achievement
{
    public partial class AchievementsPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Achievements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "NameId",
                table: "Achievements",
                type: "text",
                nullable: true);
        }
    }
}
