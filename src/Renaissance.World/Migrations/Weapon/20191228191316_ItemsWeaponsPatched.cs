using Microsoft.EntityFrameworkCore.Migrations;

namespace Renaissance.World.Migrations.Weapon
{
    public partial class ItemsWeaponsPatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "ItemsWeapons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsWeapons",
                table: "ItemsWeapons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsWeapons",
                table: "ItemsWeapons");

            migrationBuilder.RenameTable(
                name: "ItemsWeapons",
                newName: "Weapons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");
        }
    }
}
