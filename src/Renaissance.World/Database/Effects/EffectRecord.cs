using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Effects
{
    [Table("Effects")]
    public class EffectRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int IconId { get; set; }

        public int Characteristic { get; set; }

        public int Category { get; set; }

        public string Operator { get; set; }

        public bool ShowInTooltip { get; set; }

        public bool UseDice { get; set; }

        public bool ForceMinMax { get; set; }

        public bool Boost { get; set; }

        public bool Active { get; set; }

        public int OppositeId { get; set; }

        public int TheoreticalDescriptionId { get; set; }

        public int TheoreticalPattern { get; set; }

        public bool ShowInSet { get; set; }

        public int BonusType { get; set; }

        public bool UseInFight { get; set; }

        public int EffectPriority { get; set; }

        public int ElementId { get; set; }
    }
}
