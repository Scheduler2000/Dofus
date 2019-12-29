using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Npcs
{
    public class NpcContext : DofusContext<Npc>
    {
        public override DbSet<Npc> Table { get; set; }

        public NpcContext()
        {
            this.Table = base.Set<Npc>();
            Verify("Npcs");
        }
    }
}
