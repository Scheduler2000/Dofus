using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;

namespace Renaissance.World.Database.Achievements.Rewards
{
    [Table("AchievementsRewards")]
    public class AchievementRewardRecord : IRecord
    {
        [Key]
        public int Id { get; set; }

        public int AchievementId { get; set; }

        public string Criteria { get; set; }

        public double KamasRatio { get; set; }

        public double ExperienceRatio { get; set; }

        public bool KamasScaleWithPlayerLevel { get; set; }

        public List<int> ItemsReward { get; set; }

        public List<int> ItemsQuantityReward { get; set; }

        public List<int> EmotesReward { get; set; }

        public List<int> SpellsReward { get; set; }

        public List<int> TitlesReward { get; set; }

        public List<int> OrnamentsReward { get; set; }
    }
}
