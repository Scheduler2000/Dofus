using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Challenges
{
    [Table("Challenges")]
    public class Challenge : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DescriptionId { get; set; }

        public bool DareAvailable { get; set; }

        public List<int> IncompatibleChallenges { get; set; }

    }
}
