using Microsoft.EntityFrameworkCore;

using Renaissance.Database;

namespace Renaissance.World.Database.Items.Weapons
{
    public class WeaponContext : DofusContext<WeaponRecord>
    {
        public override DbSet<WeaponRecord> Table { get; set; }

        public WeaponContext()
        {
            this.Table = base.Set<WeaponRecord>();
            Verify("ItemsWeapons");
        }
    }
}
