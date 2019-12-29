using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Idol
{
    public partial class Idols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    GroupOnly = table.Column<bool>(nullable: false),
                    SpellPairId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ExperienceBonus = table.Column<int>(nullable: false),
                    DropBonus = table.Column<int>(nullable: false),
                    SynergyIdolsIds = table.Column<List<int>>(nullable: true),
                    SynergyIdolsCoeff = table.Column<List<double>>(nullable: true),
                    IncompatibleMonsters = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idols", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idols");
        }
    }
}
