using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Titles
{
    public class TitleContext : DofusContext<Title>
    {
        public override DbSet<Title> Table { get; set; }

        public TitleContext()
        {
            this.Table = base.Set<Title>();
            Verify("Titles");
        }
    }
}
