using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Achievements.Categories
{
    [Table("AchievementsCategories")]
    public class AchievementCategory : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public string Icon { get; set; }

        public int Order { get; set; }

        public string Color { get; set; }

        public List<int> AchievementIds { get; set; }

        public string VisibilityCriterion { get; set; }
    }
}
