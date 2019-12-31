using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps
{
    public class MapContext : DofusContext<MapRecord>
    {
        public override DbSet<MapRecord> Table { get; set; }

        public MapContext()
        {
            this.Table = base.Set<MapRecord>();
            Verify("Maps");
        }
    }
}
