using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Extension;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.breeds;
using Renaissance.World.Database.Breeds;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class BreedSynchroniser : AbstractSynchroniser<BreedRecord, BreedData>
    {
        private readonly D2IManager m_d2i;

        public BreedSynchroniser(D2IManager d2i, IEnumerable<BreedData> datas, IRepository<BreedRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override BreedRecord BuildEntity(BreedData data)
        {
            return new BreedRecord
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.ShortNameId),
                DescriptionId = (int)data.DescriptionId,
                BreedSpellsId = data.BreedSpellsId.Select(x => (int)x).ToArray(),
                FemaleColors = data.FemaleColors.Select(x => (int)x).ToArray(),
                MaleColors = data.MaleColors.Select(x => (int)x).ToArray(),
                MaleLook = data.MaleLook,
                FemaleLook = data.FemaleLook,
                GameplayClassDescriptionId = (int)data.GameplayClassDescriptionId,
                GameplayDescriptionId = (int)data.GameplayDescriptionId,
                SpawnMap = (int)data.SpawnMap,

                StatsPointsForAgilityCSV = data.StatsPointsForAgility.ToCSV("|", x => x.ToCSV(",")),
                StatsPointsForChanceCSV = data.StatsPointsForChance.ToCSV("|", x => x.ToCSV(",")),
                StatsPointsForIntelligenceCSV = data.StatsPointsForIntelligence.ToCSV("|", x => x.ToCSV(",")),
                StatsPointsForStrengthCSV = data.StatsPointsForStrength.ToCSV("|", x => x.ToCSV(",")),
                StatsPointsForVitalityCSV = data.StatsPointsForVitality.ToCSV("|", x => x.ToCSV(",")),
                StatsPointsForWisdomCSV = data.StatsPointsForWisdom.ToCSV("|", x => x.ToCSV(",")),
            };
        }
    }
}
