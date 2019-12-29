using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.Scrolls
{
    public class MapScrollActionContext : DofusContext<MapScrollAction>
    {
        public override DbSet<MapScrollAction> Table { get; set; }

        public MapScrollActionContext()
        {
            this.Table = base.Set<MapScrollAction>();
            Verify("MapsScrollsActions");
        }
    }
}
