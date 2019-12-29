using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Emoticon
{
    public partial class Emoticons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emoticons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    ShortcutId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    DefaultAnim = table.Column<string>(nullable: true),
                    Persistancy = table.Column<bool>(nullable: false),
                    Eight_directions = table.Column<bool>(nullable: false),
                    Aura = table.Column<bool>(nullable: false),
                    Anims = table.Column<List<string>>(nullable: true),
                    Cooldown = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    SpellLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emoticons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emoticons");
        }
    }
}
