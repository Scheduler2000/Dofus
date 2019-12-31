using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.jobs;
using Renaissance.World.Database.Jobs;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class JobSynchroniser : AbstractSynchroniser<JobRecord, JobData>
    {
        private readonly D2IManager m_d2i;


        public JobSynchroniser(D2IManager d2i, IEnumerable<JobData> datas, IRepository<JobRecord> database)
            : base(datas, database) { this.m_d2i = d2i; }



        protected override JobRecord BuildEntity(JobData data)
        {
            return new JobRecord()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                IconId = data.IconId
            };
        }
    }
}
