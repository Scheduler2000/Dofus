using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Dungeons
{
    public class DungeonContext : DofusContext<Dungeon>
    {
        public override DbSet<Dungeon> Table { get; set; }

        public DungeonContext()
        {
            this.Table = base.Set<Dungeon>();
            Verify("Dungeons");
        }
    }
}
