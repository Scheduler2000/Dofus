using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.items;
using Renaissance.World.Database.Items.Panoplies;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class ItemSetSynchroniser : AbstractSynchroniser<ItemSetRecord, ItemSetData>
    {
        private readonly D2IManager m_d2i;


        public ItemSetSynchroniser(D2IManager d2i, IEnumerable<ItemSetData> datas, IRepository<ItemSetRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override ItemSetRecord BuildEntity(ItemSetData data)
        {
            return new ItemSetRecord()
            {
                Id = (int)data.Id,
                Items = data.Items.Select(x => (int)x).ToList(),
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                Effects = data.Effects,
                BonusIsSecret = data.BonusIsSecret
            };
        }
    }
}
