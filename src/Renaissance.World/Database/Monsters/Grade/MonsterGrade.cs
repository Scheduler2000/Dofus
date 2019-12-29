using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Monsters.Grade
{
    [Table("MonstersGrades")]
    public class MonsterGrade : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int MonsterId { get; set; }

        public int Grade { get; set; }

        public int Level { get; set; }
        public int Vitality { get; set; }
        public int PaDodge { get; set; }

        public int PmDodge { get; set; }

        public int Wisdom { get; set; }

        public int EarthResistance { get; set; }

        public int AirResistance { get; set; }

        public int FireResistance { get; set; }

        public int WaterResistance { get; set; }

        public int NeutralResistance { get; set; }

        public int GradeXp { get; set; }

        public int LifePoints { get; set; }

        public int ActionPoints { get; set; }
        public int MovementPoints { get; set; }

        public int DamageReflect { get; set; }

        public int HiddenLevel { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Chance { get; set; }

        public int Agility { get; set; }

        public int StartingSpellId { get; set; }


    }
}
