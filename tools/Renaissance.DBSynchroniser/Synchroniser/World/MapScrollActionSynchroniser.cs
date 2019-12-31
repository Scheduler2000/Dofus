using System.Collections.Generic;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Maps.Scrolls;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MapScrollActionSynchroniser : AbstractSynchroniser<MapScrollActionRecord, MapScrollActionData>
    {
        public MapScrollActionSynchroniser(IEnumerable<MapScrollActionData> datas, IRepository<MapScrollActionRecord> database)
            : base(datas, database) { }

        protected override MapScrollActionRecord BuildEntity(MapScrollActionData data)
        {
            return new MapScrollActionRecord()
            {
                Id = (int)data.Id,
                RightMapId = data.RightMapId,
                BottomMapId = data.BottomMapId,
                LeftMapId = data.LeftMapId,
                TopMapId = data.TopMapId
            };
        }
    }
}
