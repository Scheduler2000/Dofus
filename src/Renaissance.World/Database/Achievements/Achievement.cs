using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Achievements
{
    [Table("Achievements")]
    public class Achievement : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int DescriptionId { get; set; }

        public int IconId { get; set; }

        public int Points { get; set; }

        public int Level { get; set; }

        public int Order { get; set; }

        public bool AccountLinked { get; set; }

        public List<int> ObjectiveIds { get; set; }

        public List<int> RewardIds { get; set; }
    }
}
