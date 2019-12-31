using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Emoticons
{
    public class EmoticonContext : DofusContext<EmoticonRecord>
    {
        public override DbSet<EmoticonRecord> Table { get; set; }

        public EmoticonContext()
        {
            this.Table = base.Set<EmoticonRecord>();
            Verify("Emoticons");
        }
    }
}
