using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.appearance;
using Renaissance.World.Database.Ornaments;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class OrnamentSynchroniser : AbstractSynchroniser<Ornament, OrnamentData>
    {
        private readonly D2IManager m_d2i;

        public OrnamentSynchroniser(D2IManager d2i, IEnumerable<OrnamentData> datas, IRepository<Ornament> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override Ornament BuildEntity(OrnamentData data)
        {
            return new Ornament()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                Visible = data.Visible,
                AssetId = data.AssetId,
                IconId = data.IconId,
                Rarity = data.Rarity,
                Order = data.Order
            };
        }
    }
}
