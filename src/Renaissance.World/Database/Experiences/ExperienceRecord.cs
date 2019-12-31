using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Experiences
{
    [Table("Experiences")]
    public class ExperienceRecord : IRecord
    {
        [Key]
        public int Level { get; set; }

        public long CharacterExp { get; set; }

        public long GuildExp { get; set; }

        public int MountExp { get; set; }

        public int AlignmentHonor { get; set; }

        public int JobExp { get; set; }
    }
}
