using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Achievements.Objectives
{
    [Table("AchievementsObjectives")]
    public class AchievementObjective : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int AchievementId { get; set; }

        public int Order { get; set; }

        public string Criterion { get; set; }

    }
}
