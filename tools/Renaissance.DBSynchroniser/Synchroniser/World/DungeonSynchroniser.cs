using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Dungeons;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class DungeonSynchroniser : AbstractSynchroniser<Dungeon, DungeonData>
    {
        private readonly D2IManager m_d2i;

        public DungeonSynchroniser(D2IManager d2i, IEnumerable<DungeonData> datas, IRepository<Dungeon> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override Dungeon BuildEntity(DungeonData data)
        {
            return new Dungeon()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                OptimalPlayerLevel = data.OptimalPlayerLevel,
                MapIds = data.MapIds,
                EntranceMapId = data.EntranceMapId,
                ExitMapId = data.ExitMapId
            };
        }
    }
}
