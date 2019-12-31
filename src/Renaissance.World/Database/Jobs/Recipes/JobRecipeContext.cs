using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs.Recipes
{
    public class JobRecipeContext : DofusContext<JobRecipeRecord>
    {
        public override DbSet<JobRecipeRecord> Table { get; set; }

        public JobRecipeContext()
        {
            this.Table = base.Set<JobRecipeRecord>();
            Verify("JobsRecipes");
        }
    }
}
