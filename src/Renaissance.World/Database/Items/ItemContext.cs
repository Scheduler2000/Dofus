using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items
{
    public class ItemContext : DofusContext<Item>
    {
        public override DbSet<Item> Table { get; set; }

        public ItemContext()
        {
            this.Table = base.Set<Item>();
            Verify("Items");
        }
    }
}
