using System.Collections.Generic;
using System.Linq;

using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.quest;
using Renaissance.World.Database.Achievements.Rewards;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class AchievementRewardSynchroniser : AbstractSynchroniser<AchievementReward, AchievementRewardData>
    {

        public AchievementRewardSynchroniser(IEnumerable<AchievementRewardData> datas, IRepository<AchievementReward> database)
            : base(datas, database) { }



        protected override AchievementReward BuildEntity(AchievementRewardData data)
        {
            return new AchievementReward()
            {
                Id = (int)data.Id,
                AchievementId = (int)data.AchievementId,
                Criteria = data.Criteria,
                KamasRatio = data.KamasRatio,
                ExperienceRatio = data.ExperienceRatio,
                KamasScaleWithPlayerLevel = data.KamasScaleWithPlayerLevel,
                ItemsReward = data.ItemsReward.Select(x => (int)x).ToList(),
                ItemsQuantityReward = data.ItemsQuantityReward.Select(x => (int)x).ToList(),
                EmotesReward = data.EmotesReward.Select(x => (int)x).ToList(),
                SpellsReward = data.SpellsReward.Select(x => (int)x).ToList(),
                TitlesReward = data.TitlesReward.Select(x => (int)x).ToList(),
                OrnamentsReward = data.OrnamentsReward.Select(x => (int)x).ToList()
            };
        }
    }
}
