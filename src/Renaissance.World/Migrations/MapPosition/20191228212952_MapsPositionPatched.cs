using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.MapPosition
{
    public partial class MapsPositionPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapsPositions",
                columns: table => new
                {
                    Id = table.Column<double>(nullable: false),
                    NameId = table.Column<int>(nullable: false),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    Outdoor = table.Column<bool>(nullable: false),
                    Capabilities = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapsPositions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapsPositions");
        }
    }
}
