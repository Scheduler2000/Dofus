using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items.Panoplies
{
    public class ItemSetContext : DofusContext<ItemSetRecord>
    {
        public override DbSet<ItemSetRecord> Table { get; set; }

        public ItemSetContext()
        {
            this.Table = base.Set<ItemSetRecord>();
            Verify("ItemsSets");
        }
    }
}
