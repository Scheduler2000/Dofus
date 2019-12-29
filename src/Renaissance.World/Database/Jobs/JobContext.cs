using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs
{
    public class JobContext : DofusContext<Job>
    {
        public override DbSet<Job> Table { get; set; }

        public JobContext()
        {
            this.Table = base.Set<Job>();
            Verify("Jobs");
        }
    }
}
