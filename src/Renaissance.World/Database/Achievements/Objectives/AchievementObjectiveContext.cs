using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Objectives
{
    public class AchievementObjectiveContext : DofusContext<AchievementObjectiveRecord>
    {
        public override DbSet<AchievementObjectiveRecord> Table { get; set; }

        public AchievementObjectiveContext()
        {
            this.Table = base.Set<AchievementObjectiveRecord>();
            Verify("AchievementsObjectives");
        }
    }
}
