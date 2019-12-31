using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs
{
    public class JobContext : DofusContext<JobRecord>
    {
        public override DbSet<JobRecord> Table { get; set; }

        public JobContext()
        {
            this.Table = base.Set<JobRecord>();
            Verify("Jobs");
        }
    }
}
