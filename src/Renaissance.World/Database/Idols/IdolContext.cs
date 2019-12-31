using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Idols
{
    public class IdolContext : DofusContext<IdolRecord>
    {
        public override DbSet<IdolRecord> Table { get; set; }


        public IdolContext()
        {
            this.Table = base.Set<IdolRecord>();
            Verify("Idols");
        }
    }
}
