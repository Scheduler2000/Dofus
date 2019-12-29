using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.effects;
using Renaissance.World.Database.Effects;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class EffectSynchroniser : AbstractSynchroniser<Effect, EffectData>
    {
        private readonly D2IManager m_d2i;

        public EffectSynchroniser(D2IManager d2i, IEnumerable<EffectData> datas, IRepository<Effect> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override Effect BuildEntity(EffectData data)
        {
            return new Effect()
            {
                Id = data.Id,
                Description = m_d2i.DataAccess.GetText((int)data.DescriptionId),
                IconId = (int)data.IconId,
                Characteristic = data.Characteristic,
                Category = (int)data.Category,
                Operator = data.Operator,
                ShowInTooltip = data.ShowInTooltip,
                UseDice = data.UseDice,
                ForceMinMax = data.ForceMinMax,
                Boost = data.Boost,
                Active = data.Active,
                OppositeId = data.OppositeId,
                TheoreticalDescriptionId = (int)data.TheoreticalDescriptionId,
                TheoreticalPattern = (int)data.TheoreticalPattern,
                ShowInSet = data.ShowInSet,
                BonusType = data.BonusType,
                UseInFight = data.UseInFight,
                EffectPriority = (int)data.EffectPriority,
                ElementId = data.ElementId
            };
        }
    }
}
