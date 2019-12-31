using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Drop.Coefficient
{
    public class MonsterDropCoefficientContext : DofusContext<MonsterDropCoefficientRecord>
    {
        public override DbSet<MonsterDropCoefficientRecord> Table { get; set; }

        public MonsterDropCoefficientContext()
        {
            this.Table = base.Set<MonsterDropCoefficientRecord>();
            Verify("MonstersDropCoefficients");
        }
    }
}
