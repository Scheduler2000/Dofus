using System.Collections.Generic;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.idols;
using Renaissance.World.Database.Idols;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class IdolSynchroniser : AbstractSynchroniser<IdolRecord, IdolData>
    {

        public IdolSynchroniser(IEnumerable<IdolData> datas, IRepository<IdolRecord> database)
            : base(datas, database) { }


        protected override IdolRecord BuildEntity(IdolData data)
        {
            return new IdolRecord()
            {
                Id = data.Id,
                Description = data.Description,
                CategoryId = data.CategoryId,
                ItemId = data.ItemId,
                GroupOnly = data.GroupOnly,
                SpellPairId = data.SpellPairId,
                Score = data.Score,
                ExperienceBonus = data.ExperienceBonus,
                DropBonus = data.DropBonus,
                SynergyIdolsIds = data.SynergyIdolsIds,
                SynergyIdolsCoeff = data.SynergyIdolsCoeff,
                IncompatibleMonsters = data.IncompatibleMonsters
            };
        }
    }
}
