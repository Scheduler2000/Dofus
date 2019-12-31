using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Ornaments
{
    public class OrnamentContext : DofusContext<OrnamentRecord>
    {
        public override DbSet<OrnamentRecord> Table { get; set; }

        public OrnamentContext()
        {
            this.Table = base.Set<OrnamentRecord>();
            Verify("Ornaments");
        }
    }
}
