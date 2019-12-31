using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs.Skills
{
    public class JobSkillContext : DofusContext<JobSkillRecord>
    {
        public override DbSet<JobSkillRecord> Table { get; set; }

        public JobSkillContext()
        {
            this.Table = base.Set<JobSkillRecord>();
            Verify("JobsSkills");
        }
    }
}
