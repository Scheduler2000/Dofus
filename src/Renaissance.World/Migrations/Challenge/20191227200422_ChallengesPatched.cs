using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Challenge
{
    public partial class ChallengesPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<int>>(
                name: "IncompatibleChallenges",
                table: "Challenges",
                nullable: true,
                oldClrType: typeof(long[]),
                oldType: "bigint[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long[]>(
                name: "IncompatibleChallenges",
                table: "Challenges",
                type: "bigint[]",
                nullable: true,
                oldClrType: typeof(List<int>),
                oldNullable: true);
        }
    }
}
