using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Emoticons
{
    [Table("Emoticons")]
    public class EmoticonRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ShortcutId { get; set; }

        public int Order { get; set; }

        public string DefaultAnim { get; set; }

        public bool Persistancy { get; set; }

        public bool Eight_directions { get; set; }

        public bool Aura { get; set; }

        public List<string> Anims { get; set; }

        public int Cooldown { get; set; }

        public int Duration { get; set; }

        public int Weight { get; set; }

        public int SpellLevelId { get; set; }

    }
}
