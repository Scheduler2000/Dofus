using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Characters
{
    public class CharacterContext : DofusContext<CharacterRecord>
    {
        public override DbSet<CharacterRecord> Table { get; set; }

        public CharacterContext()
        {
            this.Table = base.Set<CharacterRecord>();
            Verify("Characters");
        }
    }
}
