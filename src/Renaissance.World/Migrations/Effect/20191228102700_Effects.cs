using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Effect
{
    public partial class Effects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(nullable: true),
                    IconId = table.Column<int>(nullable: false),
                    Characteristic = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Operator = table.Column<string>(nullable: true),
                    ShowInTooltip = table.Column<bool>(nullable: false),
                    UseDice = table.Column<bool>(nullable: false),
                    ForceMinMax = table.Column<bool>(nullable: false),
                    Boost = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    OppositeId = table.Column<int>(nullable: false),
                    TheoreticalDescriptionId = table.Column<int>(nullable: false),
                    TheoreticalPattern = table.Column<int>(nullable: false),
                    ShowInSet = table.Column<bool>(nullable: false),
                    BonusType = table.Column<int>(nullable: false),
                    UseInFight = table.Column<bool>(nullable: false),
                    EffectPriority = table.Column<int>(nullable: false),
                    ElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effects");
        }
    }
}
