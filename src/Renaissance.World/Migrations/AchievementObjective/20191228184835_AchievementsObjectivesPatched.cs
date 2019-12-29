using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.AchievementObjective
{
    public partial class AchievementsObjectivesPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AchievementId",
                table: "AchievementsObjectives",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AchievementId",
                table: "AchievementsObjectives",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
