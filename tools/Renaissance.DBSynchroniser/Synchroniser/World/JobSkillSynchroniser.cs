using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.jobs;
using Renaissance.World.Database.Jobs.Skills;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class JobSkillSynchroniser : AbstractSynchroniser<JobSkillRecord, SkillData>
    {
        private readonly D2IManager m_d2i;

        public JobSkillSynchroniser(D2IManager d2i, IEnumerable<SkillData> datas, IRepository<JobSkillRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override JobSkillRecord BuildEntity(SkillData data)
        {
            return new JobSkillRecord()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                ParentJobId = data.ParentJobId,
                IsForgemagus = data.IsForgemagus,
                ModifiableItemTypeIds = data.ModifiableItemTypeIds,
                GatheredRessourceItem = data.GatheredRessourceItem,
                CraftableItemIds = data.CraftableItemIds,
                InteractiveId = data.InteractiveId,
                Range = data.Range,
                UseRangeInClient = data.UseRangeInClient,
                UseAnimation = data.UseAnimation,
                Cursor = data.Cursor,
                ElementActionId = data.ElementActionId,
                AvailableInHouse = data.AvailableInHouse,
                LevelMin = (int)data.LevelMin,
                ClientDisplay = data.ClientDisplay
            };
        }
    }
}
