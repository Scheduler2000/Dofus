using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.AchievementReward
{
    public partial class AchievementsPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AchievementsRewards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AchievementId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    KamasRatio = table.Column<double>(nullable: false),
                    ExperienceRatio = table.Column<double>(nullable: false),
                    KamasScaleWithPlayerLevel = table.Column<bool>(nullable: false),
                    ItemsReward = table.Column<List<int>>(nullable: true),
                    ItemsQuantityReward = table.Column<List<int>>(nullable: true),
                    EmotesReward = table.Column<List<int>>(nullable: true),
                    SpellsReward = table.Column<List<int>>(nullable: true),
                    TitlesReward = table.Column<List<int>>(nullable: true),
                    OrnamentsReward = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementsRewards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementsRewards");
        }
    }
}
