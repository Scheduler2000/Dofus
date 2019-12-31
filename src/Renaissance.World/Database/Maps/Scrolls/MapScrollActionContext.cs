using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.Scrolls
{
    public class MapScrollActionContext : DofusContext<MapScrollActionRecord>
    {
        public override DbSet<MapScrollActionRecord> Table { get; set; }

        public MapScrollActionContext()
        {
            this.Table = base.Set<MapScrollActionRecord>();
            Verify("MapsScrollsActions");
        }
    }
}
