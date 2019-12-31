using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.npcs;
using Renaissance.World.Database.Npcs;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class NpcSynchroniser : AbstractSynchroniser<NpcRecord, NpcData>
    {
        private readonly D2IManager m_d2i;


        public NpcSynchroniser(D2IManager d2i, IEnumerable<NpcData> datas, IRepository<NpcRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }

        protected override NpcRecord BuildEntity(NpcData data)
        {
            return new NpcRecord()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                Look = data.Look,
                DialogMessages = data.DialogMessages.Select(x => x.ToArray()).ToArray(),
                DialogReplies = data.DialogReplies.Select(x => x.ToArray()).ToArray(),
                Actions = data.Actions.Select(x => (int)x).ToArray(),
                TokenShop = data.TokenShop
            };
        }
    }
}
