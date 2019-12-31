using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements
{
    public class AchievementContext : DofusContext<AchievementRecord>
    {
        public override DbSet<AchievementRecord> Table { get; set; }

        public AchievementContext()
        {
            this.Table = base.Set<AchievementRecord>();
            Verify("Achievements");
        }

    }
}
