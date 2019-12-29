using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Weapon
{
    public partial class Weapons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    DescriptionId = table.Column<int>(nullable: false),
                    IconId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    RealWeight = table.Column<int>(nullable: false),
                    Cursed = table.Column<bool>(nullable: false),
                    UseAnimationId = table.Column<int>(nullable: false),
                    Usable = table.Column<bool>(nullable: false),
                    Targetable = table.Column<bool>(nullable: false),
                    Exchangeable = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    TwoHanded = table.Column<bool>(nullable: false),
                    Etheral = table.Column<bool>(nullable: false),
                    ItemSetId = table.Column<int>(nullable: false),
                    ApCost = table.Column<int>(nullable: false),
                    MinRange = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    MaxCastPerTurn = table.Column<long>(nullable: false),
                    CastInLine = table.Column<bool>(nullable: false),
                    CastInDiagonal = table.Column<bool>(nullable: false),
                    CastTestLos = table.Column<bool>(nullable: false),
                    CriticalHitProbability = table.Column<int>(nullable: false),
                    CriticalHitBonus = table.Column<int>(nullable: false),
                    CriticalFailureProbability = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    CriteriaTarget = table.Column<string>(nullable: true),
                    HideEffects = table.Column<bool>(nullable: false),
                    Enhanceable = table.Column<bool>(nullable: false),
                    NonUsableOnAnother = table.Column<bool>(nullable: false),
                    AppearanceId = table.Column<int>(nullable: false),
                    SecretRecipe = table.Column<bool>(nullable: false),
                    DropMonsterIds = table.Column<List<int>>(nullable: true),
                    RecipeSlots = table.Column<int>(nullable: false),
                    RecipeIds = table.Column<List<int>>(nullable: true),
                    BonusIsSecret = table.Column<bool>(nullable: false),
                    EvolutiveEffectIds = table.Column<List<int>>(nullable: true),
                    CraftXpRatio = table.Column<int>(nullable: false),
                    CraftVisible = table.Column<string>(nullable: true),
                    CraftFeasible = table.Column<string>(nullable: true),
                    NeedUseConfirm = table.Column<bool>(nullable: false),
                    IsDestructible = table.Column<bool>(nullable: false),
                    IsSaleable = table.Column<bool>(nullable: false),
                    FavoriteSubAreas = table.Column<List<int>>(nullable: true),
                    FavoriteSubAreasBonus = table.Column<int>(nullable: false),
                    PossibleEffectsBin = table.Column<byte[]>(nullable: true),
                    NuggetsBySubareaCSV = table.Column<string>(nullable: true),
                    ResourcesBySubareaCSV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
