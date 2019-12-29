using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.SubAreas
{
    public class MapSubAreaContext : DofusContext<MapSubArea>
    {
        public override DbSet<MapSubArea> Table { get; set; }

        public MapSubAreaContext()
        {
            this.Table = base.Set<MapSubArea>();
            Verify("MapsSubAreas");
        }
    }
}
