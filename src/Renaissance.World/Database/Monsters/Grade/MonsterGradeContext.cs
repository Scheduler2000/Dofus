using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Grade
{
    public class MonsterGradeContext : DofusContext<MonsterGradeRecord>
    {
        public override DbSet<MonsterGradeRecord> Table { get; set; }

        public MonsterGradeContext()
        {
            this.Table = base.Set<MonsterGradeRecord>();
            base.Verify("MonstersGrades");
        }
    }
}
