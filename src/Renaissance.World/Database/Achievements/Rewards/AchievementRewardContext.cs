using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Rewards
{
    public class AchievementRewardContext : DofusContext<AchievementReward>
    {
        public override DbSet<AchievementReward> Table { get; set; }

        public AchievementRewardContext()
        {
            this.Table = base.Set<AchievementReward>();
            Verify("AchievementsRewards");
        }
    }
}
