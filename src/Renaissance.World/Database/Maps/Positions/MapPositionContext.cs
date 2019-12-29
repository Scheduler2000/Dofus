using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Maps.Positions
{
    public class MapPositionContext : DofusContext<MapPosition>
    {
        public override DbSet<MapPosition> Table { get; set; }

        public MapPositionContext()
        {
            this.Table = base.Set<MapPosition>();
            Verify("MapsPositions");
        }
    }
}
