using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Map
{
    public partial class Maps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<double>(nullable: false),
                    SubAreadId = table.Column<int>(nullable: false),
                    TopNeighbourId = table.Column<int>(nullable: false),
                    BottomNeighbourId = table.Column<int>(nullable: false),
                    LeftNeighbourId = table.Column<int>(nullable: false),
                    RightNeighbourId = table.Column<int>(nullable: false),
                    FightCellsCount = table.Column<int>(nullable: false),
                    RedCells = table.Column<List<int>>(nullable: true),
                    BlueCells = table.Column<List<int>>(nullable: true),
                    OtherCells = table.Column<List<int>>(nullable: true),
                    CellsBin = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
