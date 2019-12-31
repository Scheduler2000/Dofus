using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.quest;
using Renaissance.World.Database.Achievements;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class AchievementSynchroniser : AbstractSynchroniser<AchievementRecord, AchievementData>
    {
        private readonly D2IManager m_d2i;

        public AchievementSynchroniser(D2IManager d2i, IEnumerable<AchievementData> datas, IRepository<AchievementRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override AchievementRecord BuildEntity(AchievementData data)
        {
            return new AchievementRecord()
            {
                Id = (int)data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                CategoryId = (int)data.CategoryId,
                DescriptionId = (int)data.DescriptionId,
                IconId = (int)data.IconId,
                Points = (int)data.Points,
                Level = (int)data.Level,
                Order = (int)data.Order,
                AccountLinked = data.AccountLinked,
                ObjectiveIds = data.ObjectiveIds,
                RewardIds = data.RewardIds
            };
        }
    }
}
