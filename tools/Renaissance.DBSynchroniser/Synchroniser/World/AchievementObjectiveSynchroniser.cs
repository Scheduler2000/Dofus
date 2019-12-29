using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.quest;
using Renaissance.World.Database.Achievements.Objectives;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class AchievementObjectiveSynchroniser : AbstractSynchroniser<AchievementObjective, AchievementObjectiveData>
    {
        private readonly D2IManager m_d2i;


        public AchievementObjectiveSynchroniser(D2IManager d2i, IEnumerable<AchievementObjectiveData> datas, IRepository<AchievementObjective> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override AchievementObjective BuildEntity(AchievementObjectiveData data)
        {
            return new AchievementObjective()
            {
                Id = (int)data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                AchievementId = (int)data.AchievementId,
                Order = (int)data.Order,
                Criterion = data.Criterion
            };
        }
    }
}
