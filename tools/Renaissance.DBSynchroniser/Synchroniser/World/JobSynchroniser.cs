using System.Collections.Generic;

using Renaissance.Data.D2I;
using Renaissance.Database.Pattern;
using Renaissance.DBSynchroniser.Synchroniser.Pattern;
using Renaissance.Protocol.datacenter.jobs;
using Renaissance.World.Database.Jobs;

namespace Renaissance.DBSynchroniser.Synchroniser.World
{
    public class JobSynchroniser : AbstractSynchroniser<Job, JobData>
    {
        private readonly D2IManager m_d2i;


        public JobSynchroniser(D2IManager d2i, IEnumerable<JobData> datas, IRepository<Job> database)
            : base(datas, database) { this.m_d2i = d2i; }



        protected override Job BuildEntity(JobData data)
        {
            return new Job()
            {
                Id = data.Id,
                Name = m_d2i.DataAccess.GetText((int)data.NameId),
                IconId = data.IconId
            };
        }
    }
}
