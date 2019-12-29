using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Monsters.Drop.Coefficient
{
    [Table("MonstersDropCoefficients")]
    public class MonsterDropCoefficient : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int MonsterId { get; set; }

        public int MonsterGrade { get; set; }

        public double DropCoefficient { get; set; }

        public string Criteria { get; set; }
    }
}
