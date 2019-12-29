using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Achievements.Categories
{
    public class AchievementCategoryContext : DofusContext<AchievementCategory>
    {
        public override DbSet<AchievementCategory> Table { get; set; }

        public AchievementCategoryContext()
        {
            this.Table = base.Set<AchievementCategory>();
            Verify("AchievementsCategories");
        }
    }
}
