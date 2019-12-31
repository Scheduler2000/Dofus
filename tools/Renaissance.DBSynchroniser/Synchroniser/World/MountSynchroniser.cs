using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.mounts;
using Renaissance.World.Database.Mounts;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class MountSynchroniser : AbstractSynchroniser<MountRecord, MountData>
    {
        private readonly D2IManager m_d2i;


        public MountSynchroniser(D2IManager d2i, IEnumerable<MountData> datas, IRepository<MountRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override MountRecord BuildEntity(MountData data)
        {
            return new MountRecord()
            {
                Id = (int)data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                FamilyId = (int)data.FamilyId,
                Look = data.Look,
                CertificateId = (int)data.CertificateId,
                Effects = data.Effects
            };
        }
    }
}
