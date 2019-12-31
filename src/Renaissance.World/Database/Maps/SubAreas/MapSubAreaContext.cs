using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.SubAreas
{
    public class MapSubAreaContext : DofusContext<MapSubAreaRecord>
    {
        public override DbSet<MapSubAreaRecord> Table { get; set; }

        public MapSubAreaContext()
        {
            this.Table = base.Set<MapSubAreaRecord>();
            Verify("MapsSubAreas");
        }
    }
}
