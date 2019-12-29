using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Challenges
{
    public class ChallengeContext : DofusContext<Challenge>
    {
        public override DbSet<Challenge> Table { get; set; }

        public ChallengeContext()
        {
            this.Table = base.Set<Challenge>();
            Verify("Challenges");
        }
    }
}
