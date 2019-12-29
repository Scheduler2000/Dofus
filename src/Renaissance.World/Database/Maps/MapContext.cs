using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps
{
    public class MapContext : DofusContext<Map>
    {
        public override DbSet<Map> Table { get; set; }

        public MapContext()
        {
            this.Table = base.Set<Map>();
            Verify("Maps");
        }
    }
}
