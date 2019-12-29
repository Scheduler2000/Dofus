using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Effects
{
    public class EffectContext : DofusContext<Effect>
    {
        public override DbSet<Effect> Table { get; set; }

        public EffectContext()
        {
            this.Table = base.Set<Effect>();
            Verify("Effects");
        }
    }
}
