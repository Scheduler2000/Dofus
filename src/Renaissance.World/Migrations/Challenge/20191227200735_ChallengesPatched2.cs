using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Challenge
{
    public partial class ChallengesPatched2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "Challenges",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "DescriptionId",
                table: "Challenges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
