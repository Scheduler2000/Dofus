using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.quest;
using Renaissance.World.Database.Achievements.Categories;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class AchievementCategorySynchroniser : AbstractSynchroniser<AchievementCategory, AchievementCategoryData>
    {
        private readonly D2IManager m_d2i;


        public AchievementCategorySynchroniser(D2IManager d2i, IEnumerable<AchievementCategoryData> datas, IRepository<AchievementCategory> database)
            : base(datas, database) { this.m_d2i = d2i; }



        protected override AchievementCategory BuildEntity(AchievementCategoryData data)
        {
            return new AchievementCategory()
            {
                Id = (int)data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                ParentId = (int)data.ParentId,
                Icon = data.Icon,
                Order = (int)data.Order,
                Color = data.Color,
                AchievementIds = data.AchievementIds.Select(x => (int)x).ToList(),
                VisibilityCriterion = data.VisibilityCriterion
            };
        }
    }
}
