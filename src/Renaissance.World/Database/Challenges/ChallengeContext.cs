using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Challenges
{
    public class ChallengeContext : DofusContext<ChallengeRecord>
    {
        public override DbSet<ChallengeRecord> Table { get; set; }

        public ChallengeContext()
        {
            this.Table = base.Set<ChallengeRecord>();
            Verify("Challenges");
        }
    }
}
