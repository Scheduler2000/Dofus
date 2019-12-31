using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Mounts
{
    public class MountContext : DofusContext<MountRecord>
    {
        public override DbSet<MountRecord> Table { get; set; }

        public MountContext()
        {
            this.Table = base.Set<MountRecord>();
            Verify("Mounts");
        }
    }
}
