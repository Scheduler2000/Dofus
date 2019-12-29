using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Objectives
{
    public class AchievementObjectiveContext : DofusContext<AchievementObjective>
    {
        public override DbSet<AchievementObjective> Table { get; set; }

        public AchievementObjectiveContext()
        {
            this.Table = base.Set<AchievementObjective>();
            Verify("AchievementsObjectives");
        }
    }
}
