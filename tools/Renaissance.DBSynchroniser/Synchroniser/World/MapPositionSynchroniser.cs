using System.Collections.Generic;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Maps.Positions;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MapPositionSynchroniser : AbstractSynchroniser<MapPositionRecord, MapPositionData>
    {
        public MapPositionSynchroniser(IEnumerable<MapPositionData> datas, IRepository<MapPositionRecord> database)
            : base(datas, database) { }



        protected override MapPositionRecord BuildEntity(MapPositionData data)
        {
            return new MapPositionRecord()
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
