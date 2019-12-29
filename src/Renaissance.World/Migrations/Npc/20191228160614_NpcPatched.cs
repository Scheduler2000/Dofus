using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Npc
{
    public partial class NpcPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Npcs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Gender",
                table: "Npcs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
