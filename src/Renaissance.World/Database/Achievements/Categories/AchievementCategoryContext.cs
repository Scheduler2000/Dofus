using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Categories
{
    public class AchievementCategoryContext : DofusContext<AchievementCategoryRecord>
    {
        public override DbSet<AchievementCategoryRecord> Table { get; set; }

        public AchievementCategoryContext()
        {
            this.Table = base.Set<AchievementCategoryRecord>();
            Verify("AchievementsCategories");
        }
    }
}
