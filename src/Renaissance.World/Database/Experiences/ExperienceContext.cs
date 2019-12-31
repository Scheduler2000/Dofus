using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Experiences
{
    public class ExperienceContext : DofusContext<ExperienceRecord>
    {
        public override DbSet<ExperienceRecord> Table { get; set; }

        public ExperienceContext()
        {
            this.Table = base.Set<ExperienceRecord>();
            Verify("Experiences");
        }
    }
}
