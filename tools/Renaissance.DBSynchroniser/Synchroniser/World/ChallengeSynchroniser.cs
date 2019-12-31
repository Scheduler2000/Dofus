using System.Collections.Generic;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.challenges;
using Renaissance.World.Database.Challenges;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class ChallengeSynchroniser : AbstractSynchroniser<ChallengeRecord, ChallengeData>
    {
        private readonly D2IManager m_d2i;


        public ChallengeSynchroniser(D2IManager d2i, IEnumerable<ChallengeData> datas, IRepository<ChallengeRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }


        protected override ChallengeRecord BuildEntity(ChallengeData data)
        {
            return new ChallengeRecord()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                DescriptionId = (int)data.DescriptionId,
                DareAvailable = data.DareAvailable,
                IncompatibleChallenges = data.IncompatibleChallenges.Select(x => (int)x).ToList()
            };
        }
    }
}
