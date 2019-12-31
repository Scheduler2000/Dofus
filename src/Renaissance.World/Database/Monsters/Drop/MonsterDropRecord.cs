using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;
using Renaissance.World.Database.Monsters.Drop.Coefficient;

namespace Renaissance.World.Database.Monsters.Drop
{
    [Table("MonstersDrops")]
    public class MonsterDropRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public int MonsterId { get; set; }

        public int DropId { get; set; }

        public int ObjectId { get; set; }

        public double PercentDropForGrade1 { get; set; }
        public double PercentDropForGrade2 { get; set; }
        public double PercentDropForGrade3 { get; set; }
        public double PercentDropForGrade4 { get; set; }
        public double PercentDropForGrade5 { get; set; }

        public int Count { get; set; }

        public string Criteria { get; set; }

        public Boolean HasCriteria { get; set; }

        public List<MonsterDropCoefficientRecord> SpecificDropCoefficient { get; set; }

    }
}
