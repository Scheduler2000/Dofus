using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Drop
{
    public class MonsterDropContext : DofusContext<MonsterDrop>
    {
        public override DbSet<MonsterDrop> Table { get; set; }

        public MonsterDropContext()
        {
            this.Table = base.Set<MonsterDrop>();
            Verify("MonstersDrops");
        }
    }
}
