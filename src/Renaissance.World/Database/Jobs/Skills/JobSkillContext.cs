using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Jobs.Skills
{
    public class JobSkillContext : DofusContext<JobSkill>
    {
        public override DbSet<JobSkill> Table { get; set; }

        public JobSkillContext()
        {
            this.Table = base.Set<JobSkill>();
            Verify("JobsSkills");
        }
    }
}
