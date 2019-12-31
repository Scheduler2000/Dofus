using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items
{
    public class ItemContext : DofusContext<ItemRecord>
    {
        public override DbSet<ItemRecord> Table { get; set; }

        public ItemContext()
        {
            this.Table = base.Set<ItemRecord>();
            Verify("Items");
        }
    }
}
