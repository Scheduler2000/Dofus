using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.communication;
using Renaissance.World.Database.Emoticons;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class EmoticonSynchroniser : AbstractSynchroniser<EmoticonRecord, EmoticonData>
    {
        private readonly D2IManager m_d2i;


        public EmoticonSynchroniser(D2IManager d2i, IEnumerable<EmoticonData> datas, IRepository<EmoticonRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override EmoticonRecord BuildEntity(EmoticonData data)
        {
            return new EmoticonRecord()
            {
                Id = (int)data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                ShortcutId = (int)data.ShortcutId,
                Order = (int)data.Order,
                DefaultAnim = data.DefaultAnim,
                Persistancy = data.Persistancy,
                Eight_directions = data.Eight_directions,
                Aura = data.Aura,
                Anims = data.Anims,
                Cooldown = (int)data.Cooldown,
                Duration = (int)data.Duration,
                Weight = (int)data.Weight,
                SpellLevelId = (int)data.SpellLevelId
            };
        }
    }
}
