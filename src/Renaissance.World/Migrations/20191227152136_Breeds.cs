using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations
{
    public partial class Breeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    DescriptionId = table.Column<int>(nullable: false),
                    GameplayDescriptionId = table.Column<int>(nullable: false),
                    GameplayClassDescriptionId = table.Column<int>(nullable: false),
                    MaleLook = table.Column<string>(nullable: true),
                    FemaleLook = table.Column<string>(nullable: true),
                    StatsPointsForStrengthCSV = table.Column<string>(nullable: true),
                    BreedSpellsId = table.Column<int[]>(nullable: true),
                    MaleColors = table.Column<int[]>(nullable: true),
                    FemaleColors = table.Column<int[]>(nullable: true),
                    SpawnMap = table.Column<int>(nullable: false),
                    StatsPointsForIntelligenceCSV = table.Column<string>(nullable: true),
                    StatsPointsForChanceCSV = table.Column<string>(nullable: true),
                    StatsPointsForAgilityCSV = table.Column<string>(nullable: true),
                    StatsPointsForVitalityCSV = table.Column<string>(nullable: true),
                    StatsPointsForWisdomCSV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
