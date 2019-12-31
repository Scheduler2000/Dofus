using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Drop
{
    public class MonsterDropContext : DofusContext<MonsterDropRecord>
    {
        public override DbSet<MonsterDropRecord> Table { get; set; }

        public MonsterDropContext()
        {
            this.Table = base.Set<MonsterDropRecord>();
            Verify("MonstersDrops");
        }
    }
}
