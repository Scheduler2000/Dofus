using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Idols
{
    [Table("Idols")]
    public class IdolRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int ItemId { get; set; }

        public bool GroupOnly { get; set; }

        public int SpellPairId { get; set; }

        public int Score { get; set; }

        public int ExperienceBonus { get; set; }

        public int DropBonus { get; set; }

        public List<int> SynergyIdolsIds { get; set; }

        public List<double> SynergyIdolsCoeff { get; set; }

        public List<int> IncompatibleMonsters { get; set; }

    }
}
