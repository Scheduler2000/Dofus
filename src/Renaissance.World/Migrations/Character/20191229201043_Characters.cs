using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Character
{
    public partial class Characters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(nullable: false),
                    BreedId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Look = table.Column<string>(nullable: true),
                    MapId = table.Column<int>(nullable: false),
                    CellId = table.Column<short>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    Kamas = table.Column<int>(nullable: false),
                    Experience = table.Column<long>(nullable: false),
                    StatsPoints = table.Column<int>(nullable: false),
                    Vitality = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Chance = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
