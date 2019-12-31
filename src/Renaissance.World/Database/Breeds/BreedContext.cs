using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Breeds
{
    public class BreedContext : DofusContext<BreedRecord>
    {
        public override DbSet<BreedRecord> Table { get; set; }

        public BreedContext()
        {
            this.Table = base.Set<BreedRecord>();
            Verify("Breeds");
        }
    }
}
