using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.Positions
{
    public class MapPositionContext : DofusContext<MapPositionRecord>
    {
        public override DbSet<MapPositionRecord> Table { get; set; }

        public MapPositionContext()
        {
            this.Table = base.Set<MapPositionRecord>();
            Verify("MapsPositions");
        }
    }
}
