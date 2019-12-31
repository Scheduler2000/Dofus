using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Effects
{
    public class EffectContext : DofusContext<EffectRecord>
    {
        public override DbSet<EffectRecord> Table { get; set; }

        public EffectContext()
        {
            this.Table = base.Set<EffectRecord>();
            Verify("Effects");
        }
    }
}
