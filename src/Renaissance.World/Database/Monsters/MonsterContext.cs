using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters
{
    public class MonsterContext : DofusContext<MonsterRecord>
    {
        public override DbSet<MonsterRecord> Table { get; set; }

        public MonsterContext()
        {
            this.Table = base.Set<MonsterRecord>();
            Verify("Monsters");
        }
    }
}
