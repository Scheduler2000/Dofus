using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Rewards
{
    public class AchievementRewardContext : DofusContext<AchievementRewardRecord>
    {
        public override DbSet<AchievementRewardRecord> Table { get; set; }

        public AchievementRewardContext()
        {
            this.Table = base.Set<AchievementRewardRecord>();
            Verify("AchievementsRewards");
        }
    }
}
