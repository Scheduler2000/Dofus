using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements
{
    public class AchievementContext : DofusContext<Achievement>
    {
        public override DbSet<Achievement> Table { get; set; }

        public AchievementContext()
        {
            this.Table = base.Set<Achievement>();
            Verify("Achievements");
        }

    }
}
