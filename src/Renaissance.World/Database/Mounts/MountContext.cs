using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Mounts
{
    public class MountContext : DofusContext<Mount>
    {
        public override DbSet<Mount> Table { get; set; }

        public MountContext()
        {
            this.Table = base.Set<Mount>();
            Verify("Mounts");
        }
    }
}
