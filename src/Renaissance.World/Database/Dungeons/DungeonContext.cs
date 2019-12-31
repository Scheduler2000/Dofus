using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Dungeons
{
    public class DungeonContext : DofusContext<DungeonRecord>
    {
        public override DbSet<DungeonRecord> Table { get; set; }

        public DungeonContext()
        {
            this.Table = base.Set<DungeonRecord>();
            Verify("Dungeons");
        }
    }
}
