using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items.Panoplies
{
    public class ItemSetContext : DofusContext<ItemSet>
    {
        public override DbSet<ItemSet> Table { get; set; }

        public ItemSetContext()
        {
            this.Table = base.Set<ItemSet>();
            Verify("ItemsSets");
        }
    }
}
