using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters
{
    public class MonsterContext : DofusContext<Monster>
    {
        public override DbSet<Monster> Table { get; set; }

        public MonsterContext()
        {
            this.Table = base.Set<Monster>();
            Verify("Monsters");
        }
    }
}
