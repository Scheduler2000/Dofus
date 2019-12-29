using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Ornaments
{
    public class OrnamentContext : DofusContext<Ornament>
    {
        public override DbSet<Ornament> Table { get; set; }

        public OrnamentContext()
        {
            this.Table = base.Set<Ornament>();
            Verify("Ornaments");
        }
    }
}
