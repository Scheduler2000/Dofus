using System.Collections.Generic;
using System.Linq;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Maps.SubAreas;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MapSubAreaSynchroniser : AbstractSynchroniser<MapSubArea, SubAreaData>
    {
        public MapSubAreaSynchroniser(IEnumerable<SubAreaData> datas, IRepository<MapSubArea> database)
            : base(datas, database) { }

        protected override MapSubArea BuildEntity(SubAreaData data)
        {
            return new MapSubArea()
            {
                Id = data.Id,
                NameId = (int)data.NameId,
                AreaId = data.AreaId,
                MapIds = data.MapIds,
                Level = (int)data.Level,
                MountAutoTripAllowed = data.MountAutoTripAllowed,
                Monsters = data.Monsters.Select(x => (int)x).ToList(),
                EntranceMapIds = data.EntranceMapIds,
                ExitMapIds = data.ExitMapIds,
                Achievements = data.Achievements.Select(x => (int)x).ToList(),
                Quests = data.Quests.Select(x => x.ToArray()).ToArray(),
                Npcs = data.Npcs.Select(x => x.ToArray()).ToArray(),
                ExploreAchievementId = data.ExploreAchievementId,
                IsDiscovered = data.IsDiscovered,
                Harvestables = data.Harvestables,
                AssociatedZaapMapId = data.AssociatedZaapMapId
            };
        }
    }
}
