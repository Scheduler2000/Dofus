using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Renaissance.World.Migrations.Monster
{
    public partial class Monsters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    GfxId = table.Column<int>(nullable: false),
                    Race = table.Column<int>(nullable: false),
                    Look = table.Column<string>(nullable: true),
                    UseSummonSlot = table.Column<bool>(nullable: false),
                    UseBombSlot = table.Column<bool>(nullable: false),
                    CanPlay = table.Column<bool>(nullable: false),
                    CanTackle = table.Column<bool>(nullable: false),
                    IsBoss = table.Column<bool>(nullable: false),
                    Subareas = table.Column<List<int>>(nullable: true),
                    Spells = table.Column<List<int>>(nullable: true),
                    FavoriteSubareaId = table.Column<int>(nullable: false),
                    IsMiniBoss = table.Column<bool>(nullable: false),
                    IsQuestMonster = table.Column<bool>(nullable: false),
                    CorrespondingMiniBossId = table.Column<int>(nullable: false),
                    SpeedAdjust = table.Column<double>(nullable: false),
                    CreatureBoneId = table.Column<int>(nullable: false),
                    CanBePushed = table.Column<bool>(nullable: false),
                    CanBeCarried = table.Column<bool>(nullable: false),
                    CanUsePortal = table.Column<bool>(nullable: false),
                    CanSwitchPos = table.Column<bool>(nullable: false),
                    IncompatibleIdols = table.Column<List<int>>(nullable: true),
                    AllIdolsDisabled = table.Column<bool>(nullable: false),
                    DareAvailable = table.Column<bool>(nullable: false),
                    IncompatibleChallenges = table.Column<List<int>>(nullable: true),
                    UseRaceValues = table.Column<bool>(nullable: false),
                    AggressiveZoneSize = table.Column<int>(nullable: false),
                    AggressiveLevelDiff = table.Column<int>(nullable: false),
                    AggressiveImmunityCriterion = table.Column<string>(nullable: true),
                    AggressiveAttackDelay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonstersDrops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    DropId = table.Column<int>(nullable: false),
                    ObjectId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    HasCriteria = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonstersDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonstersDrops_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonstersGrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Vitality = table.Column<int>(nullable: false),
                    PaDodge = table.Column<int>(nullable: false),
                    PmDodge = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    EarthResistance = table.Column<int>(nullable: false),
                    AirResistance = table.Column<int>(nullable: false),
                    FireResistance = table.Column<int>(nullable: false),
                    WaterResistance = table.Column<int>(nullable: false),
                    NeutralResistance = table.Column<int>(nullable: false),
                    GradeXp = table.Column<int>(nullable: false),
                    LifePoints = table.Column<int>(nullable: false),
                    ActionPoints = table.Column<int>(nullable: false),
                    MovementPoints = table.Column<int>(nullable: false),
                    DamageReflect = table.Column<int>(nullable: false),
                    HiddenLevel = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Chance = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    StartingSpellId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonstersGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonstersGrades_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonstersDropCoefficients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    MonsterGrade = table.Column<int>(nullable: false),
                    DropCoefficient = table.Column<double>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    MonsterDropId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonstersDropCoefficients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonstersDropCoefficients_MonstersDrops_MonsterDropId",
                        column: x => x.MonsterDropId,
                        principalTable: "MonstersDrops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonstersDropCoefficients_MonsterDropId",
                table: "MonstersDropCoefficients",
                column: "MonsterDropId");

            migrationBuilder.CreateIndex(
                name: "IX_MonstersDrops_MonsterId",
                table: "MonstersDrops",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonstersGrades_MonsterId",
                table: "MonstersGrades",
                column: "MonsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonstersDropCoefficients");

            migrationBuilder.DropTable(
                name: "MonstersGrades");

            migrationBuilder.DropTable(
                name: "MonstersDrops");

            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
