using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Drop.Coefficient
{
    public class MonsterDropCoefficientContext : DofusContext<MonsterDropCoefficient>
    {
        public override DbSet<MonsterDropCoefficient> Table { get; set; }

        public MonsterDropCoefficientContext()
        {
            this.Table = base.Set<MonsterDropCoefficient>();
            Verify("MonstersDropCoefficients");
        }
    }
}
