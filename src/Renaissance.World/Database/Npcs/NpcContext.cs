using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Npcs
{
    public class NpcContext : DofusContext<NpcRecord>
    {
        public override DbSet<NpcRecord> Table { get; set; }

        public NpcContext()
        {
            this.Table = base.Set<NpcRecord>();
            Verify("Npcs");
        }
    }
}
