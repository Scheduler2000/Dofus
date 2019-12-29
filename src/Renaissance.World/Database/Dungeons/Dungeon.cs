using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Dungeons
{
    [Table("Dungeons")]
    public class Dungeon : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int OptimalPlayerLevel { get; set; }

        public List<double> MapIds { get; set; }

        public double EntranceMapId { get; set; }

        public double ExitMapId { get; set; }
    }
}
