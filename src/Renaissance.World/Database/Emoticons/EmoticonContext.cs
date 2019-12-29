using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Emoticons
{
    public class EmoticonContext : DofusContext<Emoticon>
    {
        public override DbSet<Emoticon> Table { get; set; }

        public EmoticonContext()
        {
            this.Table = base.Set<Emoticon>();
            Verify("Emoticons");
        }
    }
}
