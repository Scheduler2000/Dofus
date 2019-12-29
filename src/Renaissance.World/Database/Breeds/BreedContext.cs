using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Breeds
{
    public class BreedContext : DofusContext<Breed>
    {
        public override DbSet<Breed> Table { get; set; }

        public BreedContext()
        {
            this.Table = base.Set<Breed>();
            Verify("Breeds");
        }
    }
}
