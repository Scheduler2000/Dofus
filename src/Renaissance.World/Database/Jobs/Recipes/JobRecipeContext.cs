using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs.Recipes
{
    public class JobRecipeContext : DofusContext<JobRecipe>
    {
        public override DbSet<JobRecipe> Table { get; set; }

        public JobRecipeContext()
        {
            this.Table = base.Set<JobRecipe>();
            Verify("JobsRecipes");
        }
    }
}
