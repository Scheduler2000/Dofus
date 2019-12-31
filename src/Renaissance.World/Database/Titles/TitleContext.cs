using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Titles
{
    public class TitleContext : DofusContext<TitleRecord>
    {
        public override DbSet<TitleRecord> Table { get; set; }

        public TitleContext()
        {
            this.Table = base.Set<TitleRecord>();
            Verify("Titles");
        }
    }
}
