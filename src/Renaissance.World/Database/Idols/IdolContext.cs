using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Idols
{
    public class IdolContext : DofusContext<Idol>
    {
        public override DbSet<Idol> Table { get; set; }


        public IdolContext()
        {
            this.Table = base.Set<Idol>();
            Verify("Idols");
        }
    }
}
