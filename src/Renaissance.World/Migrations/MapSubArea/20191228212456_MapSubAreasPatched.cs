using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.MapSubArea
{
    public partial class MapSubAreasPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapsSubAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    MapIds = table.Column<List<double>>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    MountAutoTripAllowed = table.Column<bool>(nullable: false),
                    Monsters = table.Column<List<int>>(nullable: true),
                    EntranceMapIds = table.Column<List<double>>(nullable: true),
                    ExitMapIds = table.Column<List<double>>(nullable: true),
                    Achievements = table.Column<List<int>>(nullable: true),
                    QuestsCSV = table.Column<string>(nullable: true),
                    NpcsCSV = table.Column<string>(nullable: true),
                    ExploreAchievementId = table.Column<int>(nullable: false),
                    IsDiscovered = table.Column<bool>(nullable: false),
                    Harvestables = table.Column<List<int>>(nullable: true),
                    AssociatedZaapMapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapsSubAreas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapsSubAreas");
        }
    }
}
