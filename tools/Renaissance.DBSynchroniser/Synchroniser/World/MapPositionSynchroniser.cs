using System.Collections.Generic;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Maps.Positions;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MapPositionSynchroniser : AbstractSynchroniser<MapPosition, MapPositionData>
    {
        public MapPositionSynchroniser(IEnumerable<MapPositionData> datas, IRepository<MapPosition> database)
            : base(datas, database) { }



        protected override MapPosition BuildEntity(MapPositionData data)
        {
            return new MapPosition()
            {
                Id = data.Id,
                NameId = data.NameId,
                PosX = data.PosX,
                PosY = data.PosY,
                Outdoor = data.Outdoor,
                Capabilities = data.Capabilities
            };
        }
    }
}
