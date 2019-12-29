using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Monsters.Grade
{
    public class MonsterGradeContext : DofusContext<MonsterGrade>
    {
        public override DbSet<MonsterGrade> Table { get; set; }

        public MonsterGradeContext()
        {
            this.Table = base.Set<MonsterGrade>();
            base.Verify("MonstersGrades");
        }
    }
}
