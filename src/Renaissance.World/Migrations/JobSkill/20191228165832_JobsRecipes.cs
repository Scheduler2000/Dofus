using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.JobSkill
{
    public partial class JobsRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobsSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentJobId = table.Column<int>(nullable: false),
                    IsForgemagus = table.Column<bool>(nullable: false),
                    ModifiableItemTypeIds = table.Column<List<int>>(nullable: true),
                    GatheredRessourceItem = table.Column<int>(nullable: false),
                    CraftableItemIds = table.Column<List<int>>(nullable: true),
                    InteractiveId = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    UseRangeInClient = table.Column<bool>(nullable: false),
                    UseAnimation = table.Column<string>(nullable: true),
                    Cursor = table.Column<int>(nullable: false),
                    ElementActionId = table.Column<int>(nullable: false),
                    AvailableInHouse = table.Column<bool>(nullable: false),
                    LevelMin = table.Column<int>(nullable: false),
                    ClientDisplay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsSkills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsSkills");
        }
    }
}
