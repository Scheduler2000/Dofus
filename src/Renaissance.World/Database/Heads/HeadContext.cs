using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Heads
{
    public class HeadContext : DofusContext<HeadRecord>
    {
        public override DbSet<HeadRecord> Table { get; set; }

        public HeadContext()
        {
            this.Table = base.Set<HeadRecord>();
            Verify("Heads");
        }
    }
}
